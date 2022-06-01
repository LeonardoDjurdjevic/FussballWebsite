﻿using Fussball_Website.Models;
using FussballWebsite.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Fussball_Website.Controllers {
    public class UserController : Controller {

        private IRepositoryDb _rep = new RepositoryDb();


        public async Task<IActionResult> Index() {
            try {
                await _rep.ConnectAsync();
                return View(_rep.GetAllUsers());
            } catch (DbException) {
                return View("_Message", new Message("Datenbankfehler",
                                "Die Benutzer konnten nicht gelanden werden",
                                "Versuchen Sie es später erneut!"));
            } finally {
                await _rep.DisconnectAsync();   
            }

        }

        [HttpGet]
        public IActionResult Registration() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(User userDataFromForm) {
            if (userDataFromForm == null) {
                return RedirectToAction("Registration");
            }
            ValidateRegistrationData(userDataFromForm);
            if (ModelState.IsValid) {
                try {
                    await _rep.ConnectAsync();
                    if (_rep.Insert(userDataFromForm).Result) {
                        return View("_Message", new Message("Registrierung", "Ihre Daten wurden erfolgreich abgespeichert"));
                    }
                    else {
                        return View("_Message", new Message("Registrierung", "Ihre Daten NICHT wurden erfolgreich abgespeichert", "Bitte versuchen sie es später erneut!"));
                    }
                }
                catch (DbException ex) {
                    return View("_Message", new Message("Registrierung", "Datenbankfehler!" + ex.Message, "Bitte versuchen sie es später erneut!"));
                }
                finally {
                    await _rep.DisconnectAsync();
                }

            }
            return View(userDataFromForm);
        }

        private void ValidateRegistrationData(User u) {
            if (u == null) {
                return;
            }

            if ((u.Username == null) || (u.Username.Trim().Length < 4)) {
                ModelState.AddModelError("Username", "Der Benutzername muss mind. 4 Zeichen lang sein!");
            }

            

            if ((u.Password == null) || (u.Password.Length < 8)) {
                ModelState.AddModelError("Password", "Das Passwort muss mind. 8 Zeichen lang sein!");
            }
            
            if (u.Birthdate >= DateTime.Now) {
                ModelState.AddModelError("Birthdate", "Das Geburtsdatum darf sich nicht in der Zukunft befinden!");
            }

        }

        private void ValidateLogin(String username, String pw) {
            if ((username == null) || (username.Trim().Length < 4)) {
                ModelState.AddModelError("Username", "Email muss laenger sein");
            }

            if ((pw == null) || (pw.Length < 8)) {
                ModelState.AddModelError("Password", "Das Passwort muss min. 8 Zeichen lang sein");
            }
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User userDataFromForm) {
            if (userDataFromForm == null) {
                return RedirectToAction("Login");
            }
            ValidateLogin(userDataFromForm.Username, userDataFromForm.Password);
            try {
                await _rep.ConnectAsync();
                if (await _rep.Login(userDataFromForm.EMail, userDataFromForm.Password) != null && !string.IsNullOrEmpty(userDataFromForm.EMail)) {
                    User u = await _rep.GetUser(userDataFromForm.EMail);
                    HttpContext.Session.SetString("username", u.Username);
                    HttpContext.Session.SetInt32("id", u.UserID);
                    int liga = Convert.ToInt32(u.Liga);
                    HttpContext.Session.SetInt32("liga", liga);
                    int role = Convert.ToInt32(u.Role);
                    HttpContext.Session.SetInt32("role", role);
                    HttpContext.Session.SetString("loggedIn", "true");
                    return View("_Message", new Message("Login", "User " + userDataFromForm.Username + 
                        " erfolgreich angemeldet!"));
                }
                else {
                    return View("_Message", new Message("Login", "Ihr Username oder Password war falsch", 
                        "Bitte überprüfen sie ihre Daten!"));
                }
            }
            catch (DbException ex) {
                return View("_Message", new Message("Registrierung", "Datenbankfehler! " + ex.Message, 
                    "Bitte versuchen sie es später erneut!"));
            }
            finally {
                await _rep.DisconnectAsync();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            try {
                await _rep.ConnectAsync();
                await _rep.Delete(id);
                return RedirectToAction("Index");
            }
            catch (DbException) {
                return View("_Message", new Message("Datenbankfehler!", "Der Benutzer konnte nicht gelöscht werden! Versuchen sie es später erneut."));
            }
            finally {
                await _rep.DisconnectAsync();
            }
        }

        [HttpGet]
        public IActionResult Update() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user, int id) {
            try {
                await _rep.ConnectAsync();
                await _rep.ChangeUserData(id, user);
                return RedirectToAction("Index");
            }
            catch (DbException) {
                return View("_Message", new Message("Datenbankfehler!", "Der Benutzer konnte nicht geändert werden! Versuchen sie es später erneut."));
            }
            finally {
                await _rep.DisconnectAsync();
            }
        }

        public async Task<IActionResult> Logout() {
            try {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("loggedIn", "false");
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    }
}
          