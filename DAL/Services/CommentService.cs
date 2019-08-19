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
    class CommentService : BaseService<Comment>
    {
        

        public override Comment Get(int id)
        {
            string query = "SELECT * FROM Comment WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("@id", id);
            return _Connection.ExecuteReader(cmd, DbToEntityMapper.ToComment).FirstOrDefault();
        }

        public override IEnumerable<Comment> GetAll()
        {
            string query = "SELECT * FROM Comment WHERE Deleted = 0";
            Command cmd = new Command(query);
            return _Connection.ExecuteReader(cmd, DbToEntityMapper.ToComment);
        }

        public override int Insert(Comment item)
        {
            string query = "INSERT INTO Comment(Content, UserId, DishId, Rating) OUTPUT inserted.id VALUES ( @content, @userId, @dishId, @rating)";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@content", item.Content);
            cmd.Parameters.Add("@userId",item.UserId);
            cmd.Parameters.Add("@dishId", item.DishId);
            cmd.Parameters.Add("@rating", item.Rating );
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(Comment item)
        {
            string query = "UPDATE Comment SET Rating = @rating, Content = @content WHERE Id = @id";
            Command cmd = new Command(query);
            cmd.Parameters.Add("@rating", item.Rating);
            cmd.Parameters.Add("@content", item.Content);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
        public override bool Delete(int id)
        {
            string query = "DELETE FROM Comment WHERE Id = @id";
            Command cmd = new Command(query);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
