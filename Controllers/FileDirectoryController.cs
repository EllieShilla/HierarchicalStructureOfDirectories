using HierarchicalStructureOfDirectories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HierarchicalStructureOfDirectories.Controllers
{
	public class FileDirectoryController : Controller
	{
		private readonly IRelationshipBetweenDirectyRepository _relationshipRepository;

		public FileDirectoryController(IRelationshipBetweenDirectyRepository relationshipRepository)
		{
			_relationshipRepository = relationshipRepository;
		}

		public async Task<ActionResult> Index(int id = 1)
		{
			ViewData["directories"] = await _relationshipRepository.GetRelationshipBetweenFileDirections(id);
			return View();
		}
	}
}
