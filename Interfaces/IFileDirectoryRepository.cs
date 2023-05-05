using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Interfaces
{
	public interface IFileDirectoryRepository
	{
		Task<FileDirectory> SaveNewFileDirectory(FileDirectory directory);
		Task SaveChanges();
		Task ClearTable();
		Task<FileDirectory> GetFirstFIleDirectory();

	}
}
