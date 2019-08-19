using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterFormModel());
        }
        [HttpPost]
        public ActionResult Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                UserService service = new UserService();
                service.Insert(model.Map<User>());
                TempData["SuccessMessage"] = "User successfully created";
                return RedirectToAction("Home", "Default");
            }
            ViewBag.ErrorMessage = "Error Occured. Please check the form.";
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginFormModel());
        }
        [HttpPost]
        public ActionResult Login(LoginFormModel model)
        {
            if (ModelState.IsValid)
            {
                UserService service = new UserService();
                User connectedUser = service.Login(model.Email, model.Password);
                if(connectedUser != null)
                {
                    Utils.Session.Instance.IsLogged = true;
                    Utils.Session.Instance.ConnectedUser = connectedUser;

                    TempData["SuccessMessage"] = "Bienvenue";
                    return RedirectToAction("Home", "Default");
                }
                ViewBag.ErrorMessage = "Login incorrect";
                return View(model);
            }
            ViewBag.ErrorMessage = "Remplissez tous les champs";
            return View(model);
        }
        public ActionResult Logout()
        {
            Utils.Session.Instance.Logout();
            TempData["SuccessMessage"] = "Au revoir";
            return RedirectToAction("Home", "Default");
        }
    }
}