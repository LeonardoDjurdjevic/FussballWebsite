using Fussball_Website.Models;
using FussballWebsite.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fussball_Website.Controllers {
    public class HomeController : Controller {

        private IRepositoryDb _rep = new RepositoryDb();

        public IActionResult Index() {
            return View();
        }
        public IActionResult Rekordhalter() {
            return View();
        }
        public IActionResult Ranking() {
            return View();
        }
        public IActionResult Registration() {
            return View();
        }
        public IActionResult Tabelle() {
            return View();
        }

        public IActionResult User() {
            return View(_rep.GetAllUsers());
        }
    }
}
