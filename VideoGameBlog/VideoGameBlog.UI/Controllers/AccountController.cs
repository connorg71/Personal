using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Models.Identity;
using VideoGameBlog.UI.Models;

namespace VideoGameBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<BlogUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            BlogUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    if (userManager.IsInRole(user.Id, "Disabled"))
                    {
                        return RedirectToAction("AccountDisabled");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Disabled")]
        public ActionResult AccountDisabled()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            AccountManager mgr = new AccountManager();

            UserListVM model = new UserListVM();

            var roles = mgr.GetAllRoles();
            var users = mgr.GetAllUsers();

            if (roles.Success)
                model.Roles = roles.Payload;
            else
            {
                throw new Exception("Roles loading improperly");
            }
            if (users.Success)
                model.Users = users.Payload;
            else
            {
                throw new Exception("Users loading improperly");
            }

            return View(model);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            AccountManager mgr = new AccountManager();
            UserVM model = new UserVM();
            List<SelectListItem> list = new List<SelectListItem>();

            var availableRoles = mgr.GetAllRoles();

            if (availableRoles.Success)
                foreach (var r in availableRoles.Payload)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = r.Name,
                        Value = r.Name
                    });
                }
            else
                return RedirectToAction("Users");

            model.AvailableRoles = list;

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddUser(UserVM model)
        {
            AccountManager mgr = new AccountManager();

            if (model.Password != model.ConfirmPasswordPrompt)
                ModelState.AddModelError("ConfirmPasswordPrompt", "Your password entries didn't match");

            if (ModelState.IsValid)
            {
                var response = mgr.AddUser(model.UserName, model.Email, model.Phone, model.Password, model.RoleName);

                if (response.Success)
                    return RedirectToAction("Users");
                else
                {
                    ModelState.AddModelError("UserName", response.Message);

                    List<SelectListItem> list = new List<SelectListItem>();

                    var availableRoles = mgr.GetAllRoles();

                    if (availableRoles.Success)
                        foreach (var r in availableRoles.Payload)
                        {
                            SelectListItem item = new SelectListItem()
                            {
                                Text = r.Name,
                                Value = r.Name
                            };
                            if (r.Name == model.RoleName)
                                item.Selected = true;
                            list.Add(item);
                        }

                    model.AvailableRoles = list;

                    return View(model);
                }
            }
            else
            {
                List<SelectListItem> list = new List<SelectListItem>();

                var availableRoles = mgr.GetAllRoles();

                if (availableRoles.Success)
                    foreach (var r in availableRoles.Payload)
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = r.Name,
                            Value = r.Name
                        };
                        if (r.Name == model.RoleName)
                            item.Selected = true;
                        list.Add(item);
                    }

                model.AvailableRoles = list;

                return View(model);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult EditUser(string name)
        {
            AccountManager mgr = new AccountManager();

            var target = mgr.GetUserByUserName(name);
            var roles = mgr.GetAllRoles();
            string RoleName = "";
            List<SelectListItem> list = new List<SelectListItem>();

            if (roles.Success)
            {
                foreach (var ur in target.Payload.Roles)
                {
                    foreach (var r in roles.Payload)
                    {
                        if (ur.RoleId == r.Id)
                            RoleName = r.Name;
                        SelectListItem item = new SelectListItem();
                        item.Text = r.Name;
                        item.Value = r.Name;
                        if (RoleName == r.Name)
                            item.Selected = true;
                        list.Add(item);
                    }
                }
            }
            else
                throw new Exception("Did not grab roles");

            if (RoleName == null || RoleName.Length < 1)
                throw new Exception("Did not connect user to role");

            if (target.Success)
            {
                UserVM model = new UserVM()
                {
                    UserName = target.Payload.UserName,
                    Email = target.Payload.Email,
                    RoleName = RoleName,
                    Phone = target.Payload.PhoneNumber,
                    AvailableRoles = list,
                    Target = name
                };

                return View(model);
            }
            else
                throw new Exception("Did not grab user");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult EditUser(UserVM model)
        {
            AccountManager mgr = new AccountManager();

            var target = mgr.GetUserByUserName(model.Target);

            if (model.Password != model.ConfirmPasswordPrompt)
                ModelState.AddModelError("ConfirmPasswordPrompt", "Your password entries didn't match");
            if (model.Target.Length < 1 && !target.Success)
                throw new Exception(target.Message);

            if (ModelState.IsValid)
            {
                var response = mgr.EditUser(target.Payload, model.UserName, model.Email, model.Phone, model.Password, model.RoleName);

                if (response.Success)
                    return RedirectToAction("Users");
                else
                {
                    ModelState.AddModelError("UserName", response.Message);

                    List<SelectListItem> list = new List<SelectListItem>();

                    var availableRoles = mgr.GetAllRoles();

                    if (availableRoles.Success)
                        foreach (var r in availableRoles.Payload)
                        {
                            SelectListItem item = new SelectListItem()
                            {
                                Text = r.Name,
                                Value = r.Name
                            };
                            if (r.Name == model.RoleName)
                                item.Selected = true;
                            list.Add(item);
                        }

                    model.AvailableRoles = list;

                    return View(model);
                }
            }
            else
            {
                List<SelectListItem> list = new List<SelectListItem>();

                var availableRoles = mgr.GetAllRoles();

                if (availableRoles.Success)
                    foreach (var r in availableRoles.Payload)
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = r.Name,
                            Value = r.Name
                        };
                        if (r.Name == model.RoleName)
                            item.Selected = true;
                        list.Add(item);
                    }

                model.AvailableRoles = list;

                return View(model);
            }
        }
    }
}