using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.BLL.Managers
{
	public class TagManager
	{
		private IAddOnlyRepo<Tag> repo;

		public TagManager()
		{
			repo = new TagRepository(new Data.EntityFramework.Entity.BlogDbContext());
		}

		public GenericResponse<List<Tag>> GetAllTags()
		{
			GenericResponse<List<Tag>> response = new GenericResponse<List<Tag>>();

			response.Payload = repo.GetAll().ToList();

			if (response.Payload != null && response.Payload.Count > 0)
			{
				response.Success = true;
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Unable to retrieve current list of tags from database.";
			}

			return response;
		}

		public GenericResponse<Tag> AddTag(Tag tag)
		{
			GenericResponse<Tag> response = new GenericResponse<Tag>();

			repo.Add(tag);
            var confirm = repo.GetAll().FirstOrDefault(t => t.TagName == tag.TagName);

            if (confirm != null)
            {
                response.Success = true;
                response.Payload = confirm;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to add Tag " + tag.TagName + " to the database";
                response.Payload = tag;
            }

            return response;
		}

        public GenericResponse<List<Tag>> ConvertTagStringToList (string userInput)
        {
            GenericResponse<List<Tag>> response = new GenericResponse<List<Tag>>();

            List<Tag> list = new List<Tag>();

            if (!userInput.Contains("#"))
            {
                response.Success = false;
                response.Message = "You must include a '#' at the start of each tag, no tags were submitted because no hashtag was supplied.";
                response.Payload = list;
            }

            string[] tagNames = userInput.Split('#');

            for (int t = 0; t < tagNames.Length; t++)
            {
                for (int i = 0; i < tagNames[t].Length; i++)
                {
                    string cursor = tagNames[t].Substring(i, 1);

                    if (cursor == " ")
                    {
                        tagNames[t] = tagNames[t].Remove(i, 1);
                    }
                }
            }

            foreach(var t in tagNames)
            {
                if (t != null && t.Length > 0)
                    list.Add(new Tag() { TagName = t });
            }

            if (list.Count == 0)
            {
                response.Success = false;
                response.Message = "ERROR : Unable to convert string of hashtags into tag models.";
                response.Payload = list;
            }
            else
            {
                response.Success = true;
                response.Payload = list;
            }

            return response;
        }
	}
}