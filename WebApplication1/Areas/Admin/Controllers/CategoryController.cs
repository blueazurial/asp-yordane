using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Mapper;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            
            return View(new CategoryModel());
        }

        public ActionResult Delete(int id)
        {
            CategoryService cs = new CategoryService();
            if(cs.Delete(id) == true)
            {
                ViewBag.SuccessMessage = "Deleted with Success";
            }else
            {
                ViewBag.ErrorMessage = "An error occured wile trying to delete";
            }
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public ActionResult AjaxAdd()
        {
            CategoryService cs = new CategoryService();
            IEnumerable<CategoryModel> model = cs.GetAll().Select(c => c.Map<CategoryModel>());
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult AjaxAdd(CategoryModel mod)
        {
            CategoryService cs = new CategoryService();
            
            if (cs.Insert(new Category { Name = mod.Name}) == 1)
            {
                ViewBag.SuccessMessage = "Successfully inserted "+mod.Name;
            } else
            {
                ViewBag.ErrorMessage = $"{mod.Name} already exists";
            }
            IEnumerable < CategoryModel > model = cs.GetAll().Select(c => c.Map<CategoryModel>());
            return PartialView(model);
        }
    }
}