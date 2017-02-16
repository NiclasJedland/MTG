using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTG.Models;
using MTG.Repository;

namespace MTG.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult StartUp()
		{
			Repo.PopulateSet();
			return RedirectToAction("Index");
		}

		public IActionResult Index()
        {
			var vm = new ViewModel();
			vm.Sets = Repo.AllSets;
			return View(vm);
        }

		public IActionResult ShowCard(string cardId, string setName)
		{
			Card card = Repo.AllSets.FirstOrDefault(s => s.Name == setName)
				.Cards.FirstOrDefault(s => s.Id == cardId);
			return View(card);
		}

		[HttpPost]
		public IActionResult Search(string search)
		{
			var vm = new ViewModel();
			vm.Cards = new List<Card>();

			vm.Cards= Repo.AllSets.SelectMany(s => s.Cards).Where(s => s.Name.ToLower().Contains(search.ToLower())).ToList();

			return View(vm);
		}
	}
}
