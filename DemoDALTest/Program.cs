using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DishService ds = new DishService();
            Console.WriteLine(ds.Get(2));
            Console.ReadKey();
        }
    }
}
