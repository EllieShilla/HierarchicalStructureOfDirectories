using HierarchicalStructureOfDirectories.Interfaces;
using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Data
{
	public class DirectoriesSave
	{
		int parentIndexToSaveInRelationshipTable = 0;
		int directoryIdByTheirDipLevel = 0;
		int oneIteration = 1;

		public async Task SaveDirecoryToDB(string sDir, IRelationshipBetweenDirectyRepository _relationshipRepository, IFileDirectoryRepository _directoryRepository)
		{
			List<FileDirectory> allDirectories = DictionaryTree.GetDirectoryTree(new DirectoryInfo(sDir), "", new List<FileDirectory>());
			allDirectories = allDirectories.Take(allDirectories.Count / 2).ToList();

			FileDirectory mainDirectory = new FileDirectory() { DirectoryName = allDirectories[0].DirectoryName };
			mainDirectory = await _directoryRepository.SaveNewFileDirectory(mainDirectory);

			parentIndexToSaveInRelationshipTable = mainDirectory.Id;

			for (int i = 1; i <= allDirectories.Count; i++)
			{
				int nextIndex = i;
				do
				{
					directoryIdByTheirDipLevel = allDirectories[nextIndex].Id;

					FileDirectory subDirectory = new FileDirectory() { DirectoryName = allDirectories[nextIndex].DirectoryName };
					subDirectory = await _directoryRepository.SaveNewFileDirectory(subDirectory);

					RelationshipBetweenFileDirection relation = new RelationshipBetweenFileDirection()
					{
						DirectoryParentId = parentIndexToSaveInRelationshipTable,
						DirectoryChildId = subDirectory.Id
					};
					await _relationshipRepository.SaveNewRelationship(relation);

					if (nextIndex + 1 < allDirectories.Count)
					{
						nextIndex = nextIndex + oneIteration;

						if (directoryIdByTheirDipLevel < allDirectories[nextIndex].Id)
							parentIndexToSaveInRelationshipTable = subDirectory.Id;
						else
							parentIndexToSaveInRelationshipTable = mainDirectory.Id;

						++nextIndex;
					}
					else
					{
						directoryIdByTheirDipLevel = allDirectories.Count + 10;
					}

				} while (directoryIdByTheirDipLevel < allDirectories[nextIndex].Id);

				if (i != allDirectories.Count - 1)
					i = nextIndex - oneIteration;
				else
					i = allDirectories.Count;

			}
		}
	}
}
