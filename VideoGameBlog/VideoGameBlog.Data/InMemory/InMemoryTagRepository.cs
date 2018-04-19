using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.InMemory
{
	public class InMemoryTagRepository : IAddOnlyRepo<Tag>
	{
		private static List<Tag> tags = new List<Tag>
		{
			new Tag{Id = 1, TagName = "FPS"},
			new Tag{Id = 2, TagName = "RPG"},
			new Tag{Id = 3, TagName = "RTS"},
			new Tag{Id = 4, TagName = "Strategy"},
			new Tag{Id = 5, TagName = "BaseBuilding"},
			new Tag{Id = 6, TagName = "HackAndSlash"},
			new Tag{Id = 7, TagName = "TPS"},
			new Tag{Id = 8, TagName = "RedDead"},
			new Tag{Id = 9, TagName = "Fallout"},
			new Tag{Id = 10, TagName = "DwarfFortress"},
			new Tag{Id = 11, TagName = "AntiEstablishment"}
		};

		public void Add(Tag newItem)
		{
			newItem.Id = tags.Max(i => i.Id) + 1;
			tags.Add(newItem);
		}

		public Tag Get(int id)
		{
			return tags.FirstOrDefault(i => i.Id == id);
		}

		public IList<Tag> GetAll()
		{
			return tags;
		}
	}
}