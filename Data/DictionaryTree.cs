using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Data
{
	public class DictionaryTree
	{
		public static List<FileDirectory> GetDirectoryTree(DirectoryInfo dir, string indent, List<FileDirectory> list, int id = 0)
		{
			list.Add(new FileDirectory() { DirectoryName = dir.Name, Id = id });
			id++;

			foreach (DirectoryInfo subDir in dir.GetDirectories())
			{
				GetDirectoryTree(subDir, indent + "  ", list, id);
			}

			return list;
		}
	}
}
