using DAL.Entities;
using DAL.Mappers;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CategoryService: BaseService<Category>
    {
        

        public override Category Get(int id)
        {
            string query = "SELECT * FROM Category WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("@id", id);
            return _Connection.ExecuteReader(cmd, UniversalDbToEntityMapper.Mapper<Category>).FirstOrDefault();
        }

        public override IEnumerable<Category> GetAll()
        {
            string query = "SELECT * FROM Category WHERE Deleted = 0";
            Command cmd = new Command(query);
            return _Connection.ExecuteReader(cmd, DbToEntityMapper.ToCategory);
        }

        public override int Insert(Category item)
        {
            string query = "INSERT INTO Category(Name) OUTPUT inserted.id VALUES (@name)";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@name", item.Name);
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(Category item)
        {
            string query = "UPDATE Category SET Name = @name WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@name", item.Name);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
        public override bool Delete(int id)
        {
            string query = "DELETE FROM Category WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@id", id);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
        
    }
}
