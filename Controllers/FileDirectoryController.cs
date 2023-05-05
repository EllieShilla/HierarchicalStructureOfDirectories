using HierarchicalStructureOfDirectories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HierarchicalStructureOfDirectories.Data;

namespace HierarchicalStructureOfDirectories.Controllers
{
	public class FileDirectoryController : Controller
	{
		private readonly IRelationshipBetweenDirectyRepository _relationshipRepository;
		private readonly IFileDirectoryRepository _directoryRepository;
		DirectoriesSave directoriesSave;

		public FileDirectoryController(IRelationshipBetweenDirectyRepository relationshipRepository, IFileDirectoryRepository directoryRepository)
		{
			_relationshipRepository = relationshipRepository;
			_directoryRepository = directoryRepository;
			directoriesSave = new DirectoriesSave();
		}

		public async Task<ActionResult> Index(int id = 0)
		{
			if (id == 0)
			{
				var directory = await _directoryRepository.GetFirstFIleDirectory();
				id = directory.Id;
			}

			ViewData["directories"] = await _relationshipRepository.GetRelationshipBetweenFileDirections(id);
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Upload(string sDir)
		{
			await _relationshipRepository.ClearTable();
			await _directoryRepository.ClearTable();
			await directoriesSave.SaveDirecoryToDB(sDir, _relationshipRepository, _directoryRepository);

			return RedirectToAction("Index");
		}
	}
}
