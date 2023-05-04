using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Helpers
{
	public static class Mapper
	{
		public static FileDirectory FileDirectoryMapp(int id, string directoryName)
		{
			return new FileDirectory()
			{
				Id = id,
				DirectoryName = directoryName
			};
		}
	}
}
