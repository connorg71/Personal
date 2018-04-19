using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.InMemory
{
	public class InMemoryStaticPageRepository : IVideoGameBlogRepository<StaticPage>
	{
		private static List<StaticPage> staticPages = new List<StaticPage>
		{
			new StaticPage{Id = 1, StaticPageContent = @"<p>Mizzen keel barque careen pinnace lateen sail case shot man-of-war rum quarter. Grog capstan take a caulk smartly rope's end hearties spirits man-of-war weigh anchor Sea Legs. Me gunwalls chase guns provost hail-shot code of conduct Letter of Marque strike colors reef matey.

Line salmagundi bilge rat trysail gabion log red ensign keelhaul heave to sutler. Cat o'nine tails bowsprit rigging topgallant red ensign flogging Letter of Marque killick sutler driver. Gangplank scourge of the seven seas Sail ho league hornswaggle Chain Shot man-of-war me aft scuppers.

Clap of thunder fire in the hole deadlights line list Blimey swab long clothes plunder square-rigged. Tack square-rigged clap of thunder bilged on her anchor carouser flogging gaff no prey, no pay spirits topmast. Sutler Sink me maroon hail-shot aft brig code of conduct chandler grog blossom knave.</p>", StaticPageImageFileName = "masterchief.jpg", StaticPageTitle = "Contact"},
			new StaticPage{Id = 2, StaticPageContent = @"<p>Mizzen keel barque careen pinnace lateen sail case shot man-of-war rum quarter. Grog capstan take a caulk smartly rope's end hearties spirits man-of-war weigh anchor Sea Legs. Me gunwalls chase guns provost hail-shot code of conduct Letter of Marque strike colors reef matey.

Line salmagundi bilge rat trysail gabion log red ensign keelhaul heave to sutler. Cat o'nine tails bowsprit rigging topgallant red ensign flogging Letter of Marque killick sutler driver. Gangplank scourge of the seven seas Sail ho league hornswaggle Chain Shot man-of-war me aft scuppers.

Clap of thunder fire in the hole deadlights line list Blimey swab long clothes plunder square-rigged. Tack square-rigged clap of thunder bilged on her anchor carouser flogging gaff no prey, no pay spirits topmast. Sutler Sink me maroon hail-shot aft brig code of conduct chandler grog blossom knave.</p>", StaticPageImageFileName = "pyramidScheme.jpg", StaticPageTitle = "About Us"},
			new StaticPage{Id = 3, StaticPageContent = @"<p>Mizzen keel barque careen pinnace lateen sail case shot man-of-war rum quarter. Grog capstan take a caulk smartly rope's end hearties spirits man-of-war weigh anchor Sea Legs. Me gunwalls chase guns provost hail-shot code of conduct Letter of Marque strike colors reef matey.

Line salmagundi bilge rat trysail gabion log red ensign keelhaul heave to sutler. Cat o'nine tails bowsprit rigging topgallant red ensign flogging Letter of Marque killick sutler driver. Gangplank scourge of the seven seas Sail ho league hornswaggle Chain Shot man-of-war me aft scuppers.

Clap of thunder fire in the hole deadlights line list Blimey swab long clothes plunder square-rigged. Tack square-rigged clap of thunder bilged on her anchor carouser flogging gaff no prey, no pay spirits topmast. Sutler Sink me maroon hail-shot aft brig code of conduct chandler grog blossom knave.</p>", StaticPageImageFileName = "knifeTypes.jpg", StaticPageTitle = "Recommended Blogs"}
		};

		public void Add(StaticPage newItem)
		{
			newItem.Id = staticPages.Max(i => i.Id) + 1;
			staticPages.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			staticPages.Remove(existing);
		}

		public void Edit(StaticPage item)
		{
			var existing = Get(item.Id);
			if (existing == null)
			{
				return;
			}
			existing.StaticPageContent = item.StaticPageContent;
			existing.StaticPageImageFileName = item.StaticPageImageFileName;
			existing.StaticPageTitle = item.StaticPageTitle;
		}

		public StaticPage Get(int id)
		{
			return staticPages.FirstOrDefault(i => i.Id == id);
		}

		public IList<StaticPage> GetAll()
		{
			return staticPages;
		}
	}
}