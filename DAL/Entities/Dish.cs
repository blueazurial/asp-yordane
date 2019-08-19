using DAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dish
    {
        [IgnoreOnInsert]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? Discount { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        [IgnoreOnInsert]
        public bool Active { get; set; }
    }
}
