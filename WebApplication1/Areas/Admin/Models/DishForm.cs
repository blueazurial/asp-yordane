using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Mapper;

namespace WebApplication1.Areas.Admin.Models
{
    public class DishForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }

        //permet de récupérer une image
        public HttpPostedFileBase File { get; set; }
        public int CategoryId { get; set; }
        private IEnumerable<CategoryModel> _AllCategories;
        public IEnumerable<CategoryModel> AllCategories
        {
            get
            {
                if(_AllCategories == null)
                {
                    CategoryService cs = new CategoryService();
                    _AllCategories = cs.GetAll().Select(c => c.Map<CategoryModel>()) ;
                }
                return _AllCategories;
            }
        }
    }
}