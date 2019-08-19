using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Mapper;

namespace WebApplication1.Models
{
    public class DishListModel
    {
        private IEnumerable<DishDetailsModel> _ListDish;
        public IEnumerable<DishDetailsModel> ListDish
        {
            get
            {
                if (_ListDish == null)
                {
                    DishService cs = new DishService();
                    _ListDish = cs.GetAll().Select(c => c.Map<DishDetailsModel>());
                }
                return _ListDish;
            }
        }
        private IEnumerable<CategoryModel> _Categories;
        public IEnumerable<CategoryModel> Categories
        {
            get
            {
                if (_Categories == null)
                {
                    CategoryService cs = new CategoryService();
                    _Categories = cs.GetAll().Select(c => c.Map<CategoryModel>());
                }
                return _Categories;
            }
        }


    }
}