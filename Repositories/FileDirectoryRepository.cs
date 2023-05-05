using HierarchicalStructureOfDirectories.Data;
using HierarchicalStructureOfDirectories.Interfaces;
using HierarchicalStructureOfDirectories.Models;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalStructureOfDirectories.Repositories
{
	public class FileDirectoryRepository : IFileDirectoryRepository
	{
		private readonly DirectoriesContext _context;

		public FileDirectoryRepository(DirectoriesContext context)
		{
			_context = context;
		}

		public async Task<FileDirectory> SaveNewFileDirectory(FileDirectory directory)
		{
			_context.Directorys.Add(directory);
			await SaveChanges();
			return directory;
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task ClearTable()
		{
			_context.Directorys.RemoveRange(_context.Directorys);
			await SaveChanges();
		}

		public async Task<FileDirectory> GetFirstFIleDirectory()
		{
			return await _context.Directorys.FirstOrDefaultAsync();
		}
	}
}
