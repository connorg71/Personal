using DvdModels;
using System.Data.Entity;

namespace DvdData
{
	public class DvdContext : DbContext
	{
		public DvdContext() : base("DefaultConnection")
		{
		}

		public DbSet<Dvd> Dvds { get; set; }
	}
}