using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SearchFormModel
    {
        public string NameSushi { get; set; }
        private IEnumerable<Category> _AllCategories;
        public List<int> PickedCategories { get; set; }
        public IEnumerable<Category> AllCategories {
            get
            {

                return _AllCategories = _AllCategories ?? (new CategoryService()).GetAll();
            }
        }
    }
}