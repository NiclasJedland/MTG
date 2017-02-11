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
        public IActionResult Index()
        {
			var vm = new ViewModel();

			vm.Sets = Repo.PopulateSet();

			return View(vm);
        }
    }
}
