using HierarchicalStructureOfDirectories.Data;
using HierarchicalStructureOfDirectories.Helpers;
using HierarchicalStructureOfDirectories.Interfaces;
using HierarchicalStructureOfDirectories.Models;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalStructureOfDirectories.Repositories
{
	public class RelationshipBetweenDirectyRepository : IRelationshipBetweenDirectyRepository
	{
		private readonly DirectoriesContext _context;

		public RelationshipBetweenDirectyRepository(DirectoriesContext context)
		{
			_context = context;
		}

		public async Task<ParentDirectoryData> GetRelationshipBetweenFileDirections(int parentDirectoryId)
		{
			var relationshipBetweenFileDirections = await GetRelationshipByParentID(parentDirectoryId);
			List<FileDirectory> fileDirectories = new List<FileDirectory>();

			foreach (var file in relationshipBetweenFileDirections)
			{
				fileDirectories.Add(Mapper.FileDirectoryMapp(file.DirectoryChildId, GetDirectionNameById(file.DirectoryChildId)));
			}

			return new ParentDirectoryData()
			{
				Id = parentDirectoryId,
				Name = GetDirectionNameById(parentDirectoryId),
				ChildsDirecories = fileDirectories
			};
		}

		public string GetDirectionNameById(int id)
		{
			return _context.Directorys.FirstOrDefault(i => i.Id == id).DirectoryName;
		}

		public async Task<List<RelationshipBetweenFileDirection>> GetRelationshipByParentID(int parentId)
		{
			return await _context.RelationshipBetweenFiles.Where(i => i.DirectoryParentId == parentId).ToListAsync();
		}
	}
}
