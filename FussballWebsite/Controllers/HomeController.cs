using Fussball_Website.Models;
using FussballWebsite.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Fussball_Website.Controllers {
    public class HomeController : Controller {

        private IRepositoryDb _rep = new RepositoryDb();

        public IActionResult Index() {
            if(HttpContext.Session.GetString("loggedIn") == "false") {
                HttpContext.Session.SetInt32("role", 2);
            }
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
        public async Task<IActionResult> User() {
            try {
                await _rep.ConnectAsync();
                return View("User", _rep.GetAllUsers());
            } catch (DbException) {
                return View("_Message", new Message("Datenbankfehler",
                                "Die Benutzer konnten nicht gelanden werden",
                                "Versuchen Sie es später erneut!"));
            } finally {
                await _rep.DisconnectAsync();
            } 
            
        }
    }
}
