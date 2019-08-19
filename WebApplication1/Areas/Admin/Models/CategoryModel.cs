using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private int? _Quantity;
        public int? Quantity
        {
            get
            {
                if (_Quantity == null)
                {
                    DishService ds = new DishService();
                    _Quantity = ds.GetCountByCategory(Id);
                }
                return _Quantity;
            }
        }

    }
}