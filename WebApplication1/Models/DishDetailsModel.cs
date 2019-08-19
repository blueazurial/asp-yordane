using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DishDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? Discount { get; set; }
        public int CategoryId { get; set; }
        private Category _Category;
        public Category Category
        { //Lazy Loading
            get
            {
                return _Category = _Category ?? (new CategoryService()).Get(CategoryId);
            }
        }
        public string Picture { get; set; }
        public float PriceWithDiscount { get { return Price - (Price * (Discount ?? 0) / 100); } }
        public IEnumerable<Comment> Comments { get; set; }
    }
}