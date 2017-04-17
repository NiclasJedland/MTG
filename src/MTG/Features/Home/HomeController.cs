using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MTG.Core.Data;
using MTG.Models;
using MTG.Repository;
using Sakura.AspNetCore;

namespace MTG.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult StartUp()
		{
			SetRepository.PopulateSet();

			return RedirectToAction("Index");
		}

		public IActionResult Index(HomeViewModel vm, int currentPageSet, int currentPageCard, string highlightedSet)
		{
			if (currentPageSet == 0)
				currentPageSet = StaticVariables.CurrentPageSet;

			vm.CurrentPageSet = currentPageSet;
			vm.CurrentPageCard = currentPageCard;


			SetStaticVariables(vm);

			vm.Sets = SetRepository.AllSets;

			vm.PaginatedSet = vm.Sets.OrderByDescending(s => s.ReleaseDate).ToPagedList(StaticVariables.PageSizeSet, StaticVariables.CurrentPageSet);

			foreach (var item in vm.PaginatedSet)
			{
				//Paginate Cards
				item.PaginatedCard = item.Cards.OrderBy(s => s.Rarity).ToPagedList(StaticVariables.PageSizeCard, StaticVariables.CurrentPageCard);
			}

			return View(vm);
		}

		public IActionResult ShowCard(string cardId, string setName)
		{
			Card card = SetRepository.AllSets.FirstOrDefault(s => s.Name == setName)
				.Cards.FirstOrDefault(s => s.Id == cardId);
			return View(card);
		}

		[HttpPost]
		public IActionResult Search(HomeViewModel vm, string search, string searchType, int page)
		{
			if (string.IsNullOrEmpty(search))
				return RedirectToAction("Index");

			if (searchType == "Cards")
			{
				vm.Cards = new List<Card>();
				vm.Cards = SetRepository.AllSets.SelectMany(s => s.Cards)
					.Where(s => s.Name.ToLower().Contains(search.ToLower())).ToList();

				if (vm.Cards.Count() == 0)
					return RedirectToAction("Index");

				return View(vm);
			}
			else if (searchType == "Sets")
			{
				vm.Sets = new List<Set>();

				vm.Sets = SetRepository.AllSets.Where(s => s.Name.ToLower().Contains(search.ToLower())
					|| s.Code.ToLower().Contains(search.ToLower())
					|| s.Block.ToLower() == search.ToLower()
					).ToList();

				if (vm.Sets.Count() == 0)
					return RedirectToAction("Index");

				return View("Index", vm);
			}

			return View("Error");
		}

		public IActionResult SearchBlock(string search)
		{
			var vm = new HomeViewModel();
			vm.Sets = SetRepository.AllSets.Where(s => s.Block == search).ToList();

			return View("Index", vm);
		}

		private void SetStaticVariables(HomeViewModel vm)
		{
			StaticVariables.CurrentPageCard = vm.CurrentPageCard > 0 ? vm.CurrentPageCard : 1;
			StaticVariables.CurrentPageSet = vm.CurrentPageSet > 0 ? vm.CurrentPageSet : 1;
			StaticVariables.PageSizeCard = vm.PageSizeCard > 0 ? vm.PageSizeCard : 12;
			StaticVariables.PageSizeSet = vm.PageSizeSet > 0 ? vm.PageSizeSet : 5;

			StaticVariables.HighlightedSets = vm.HighlightedSets;
		}
	}
}
