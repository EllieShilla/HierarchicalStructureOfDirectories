using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Interfaces
{
	public interface IRelationshipBetweenDirectyRepository
	{
		Task<ParentDirectoryData> GetRelationshipBetweenFileDirections(int parentDirectoryId);
		string GetDirectionNameById(int id);
		Task<List<RelationshipBetweenFileDirection>> GetRelationshipByParentID(int parentId);
	}
}
