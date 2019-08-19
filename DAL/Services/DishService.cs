using DAL.Attributes;
using DAL.Entities;
using DAL.Mappers;
using DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DishService : BaseService<Dish>
    {
        public override Dish Get(int Id) //select * from Dish where ID = Id
        {
            string query = "SELECT * FROM Dish WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("@id", Id);
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Dish>).FirstOrDefault(); 
        }

        public override IEnumerable<Dish> GetAll() //select * from Dish
        {
            string query = "SELECT * FROM Dish WHERE Deleted = 0";
            Command cmd = new Command(query);
            return _Connection.ExecuteReader(cmd, DbToEntityMapper.ToDish);
        }
        public override int Insert(Dish dish) //INSERT INTO Dish
        {
            string query = "INSERT INTO Dish(Name, Price, Discount, Picture, CategoryId) OUTPUT inserted.id VALUES ( @name, @price, @discount, @picture, @categoryId)";
            Command cmd = new Command(query);
            //cmd.Parameters.Add("@name", dish.Name);
            //cmd.Parameters.Add("@price", dish.Price);
            //cmd.Parameters.Add("@discount", (object)dish.Discount);
            //cmd.Parameters.Add("@picture", (object)dish.Picture);
            //cmd.Parameters.Add("@categoryId", dish.CategoryId);
            cmd.SetParameters<IgnoreOnInsert>(dish);
            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool  Update(Dish dish) //Update Dish 
        {
            string query = "UPDATE Dish SET Name = @name, Price = @price, Discount = @discount, Picture = @picture, CategoryID = @categoryId WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@name", dish.Name);
            cmd.Parameters.Add("@id", dish.Id);
            cmd.Parameters.Add("@price", dish.Price);
            cmd.Parameters.Add("@discount", (object)dish.Discount ?? DBNull.Value);
            cmd.Parameters.Add("@picture", (object)dish.Picture ?? DBNull.Value);
            cmd.Parameters.Add("@categoryId", dish.CategoryId);
            return (_Connection.ExecuteNonQuery(cmd) == 1);
        }
        public override bool Delete(int id)
        {
            string query = "DELETE FROM Dish WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@id", id);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
        public int GetCountByCategory(int id)
        {
            
            return GetAll().Where(d => d.CategoryId == id).Count();
        }

    }
}
