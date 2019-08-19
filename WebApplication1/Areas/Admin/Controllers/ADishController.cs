using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Mapper;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class ADishController : Controller
    {
        // GET: Admin/ADish
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new DishForm());
        }
        [HttpPost]
        public ActionResult Create(DishForm model)
        {
            Dish toInsert = model.Map<Dish>();
            if (ModelState.IsValid)
            {
                //gestion image
                if(model.File != null)
                {
                    string name = Guid.NewGuid().ToString() + model.File.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/Image"), name);
                    //placer image dans un dossier
                    model.File.SaveAs(path);
                    toInsert.Picture = name;
                }

                //Inserer en db
                DishService ds = new DishService();

                ds.Insert(toInsert);

                ViewBag.SuccessMessage = "Dish inserted";

                return RedirectToAction("Dish", "Index", new { Area = "" });
            }
            return View(model);
        }
    }
}