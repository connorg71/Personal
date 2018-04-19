using System;

namespace DvdData
{
	public class RepositoryFactory
	{
		public IDvdRepository Create(string repositoryType)
		{
			switch (repositoryType)
			{
				case "InMemory":
					return new InMemoryRepository();

				case "EntityFramework":
					return new EfRepository();

				case "Ado":
					return new AdoRepository();

				default:
					throw new InvalidOperationException();
			}
		}
	}
}