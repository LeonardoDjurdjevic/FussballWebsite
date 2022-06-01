using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fussball_Website.Controllers {
    public class HomeController : Controller {
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
    }
}
