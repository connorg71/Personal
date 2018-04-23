using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult AddState()
        {
            var model = new State();
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }
        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            var model = StateRepository.Get(stateAbbreviation);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            var model = new Course();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            CourseRepository.Add(course.CourseName);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditCourse(int courseId)
        {
            var model = CourseRepository.Get(courseId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int courseId)
        {
            var model = CourseRepository.Get(courseId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
        
    }
}