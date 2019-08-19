using DAL.Attributes;
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
    public class UserService : BaseService<User>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override User Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [User]");
            return _Connection.ExecuteReader(cmd, DbToEntityMapper.ToUser);
        }

        public override int Insert(User item)
        {
            Command cmd = new Command("SP_Register", true);
            //cmd.AddParameter("@email", item.Email);
            //cmd.AddParameter("@password", item.Password);
            //cmd.AddParameter("@lastname", item.LastName);
            //cmd.AddParameter("@firstname", item.FirstName);
            //cmd.AddParameter("@birthdate", item.BirthDate);
            //cmd.AddParameter("@number", item.Number);
            //cmd.AddParameter("@street", item.Street);
            //cmd.AddParameter("@zipcode", item.ZipCode);
            //cmd.AddParameter("@city", item.City);
            cmd.SetParameters<IgnoreOnInsert>(item);

            return _Connection.ExecuteNonQuery(cmd);






        }

        public override bool Update(User item)
        {
            throw new NotImplementedException();
        }
        public User Login(string user, string password)
        {
            Command cmd = new Command("SP_Login", true);
            cmd.AddParameter("@email", user);
            cmd.AddParameter("@password", password);
            return (User)_Connection.ExecuteReader(cmd, DbToEntityMapper.ToUser).FirstOrDefault();
        }
    }
}
