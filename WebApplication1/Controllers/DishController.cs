using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Security;

namespace WebApplication1.Controllers
{
    public class DishController : Controller
    {
        // GET: Dish
        public ActionResult Index()
        {
            DishService dishService = new DishService();
            IEnumerable<Dish> collection = dishService.GetAll();
            IEnumerable<DishDetailsModel> model = collection.Select(item => item.Map<DishDetailsModel>());
            return View(model);
        }
        public ActionResult Details(int id)
        {
            DishService dishService = new DishService();
            Dish dish = dishService.Get(id);
            DishDetailsModel model = dish.Map<DishDetailsModel>();
            return View(model);
        }
        [CustomSecurity("CUSTOMER", "ADMIN")]
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View(new SearchFormModel());
        }
        [HttpPost]
        public ActionResult AjaxSearch(SearchFormModel model)
        {
            DishService ds = new DishService();
            IEnumerable<Dish> AllDishes = ds.GetAll();
            IEnumerable<DishDetailsModel> result = AllDishes
                .Where(d => d.Name.ToLower().Contains(model.NameSushi?.ToLower() ?? string.Empty))
                .Select(d => d.Map<DishDetailsModel>());
            if(model.PickedCategories != null)
            {
                result = result.Where(d => model.PickedCategories.Contains(d.CategoryId));
            }
            return PartialView(result);
        }
        [HttpPost]
        public ActionResult AjaxAddResult(DishDetailsModel dish)
        {

            return PartialView();
        }
        public ActionResult DishList()
        {

            return View();
        }

        
    }
}