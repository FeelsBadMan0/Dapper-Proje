using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Concrete.Dapper
{
    public class DpInterestRepository : IInterestRepository
    {
        private readonly IDbConnection _db;
        public DpInterestRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Interest interest)
        {
            var sql = "Delete from Interests where ID=@ID";
            _db.Execute(sql, new { interest.ID });

        }

        public List<Interest> GetAll()
        {
            var sql = "Select * from Interests";
            return _db.Query<Interest>(sql).ToList();
        }

        public Interest GetById(int id)
        {
            var sql = "Select * from Interests where ID=@ID";
            return _db.Query<Interest>(sql, new { @ID = id }).Single();
        }

        public void Insert(Interest interest)
        {
            var sql = "Insert into Interests values(@Description)";
            _db.Execute(sql, new
            {
                @Description = interest.Description
            });
        }

        public void Update(Interest interest)
        {
            var sql = "Update Interests set Description=@Description where ID=@ID";
            _db.Execute(sql, new
            {
                @Description = interest.Description,
                @ID = interest.ID
            });
        }
    }
}
