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
    public class DpSkillRepository : ISkillRepository
    {
        private readonly IDbConnection _db;
        public DpSkillRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Skill skill)
        {
            var sql = "Delete from Skills where ID=@ID";
            _db.Execute(sql, new { skill.ID });
        }

        public List<Skill> GetAll()
        {
            var sql = "Select * from Skills";
            return _db.Query<Skill>(sql).ToList();
        }

        public Skill GetById(int id)
        {
            var sql = "Select * from Skills where ID=@ID";
            return _db.Query<Skill>(sql, new { @ID = id }).Single();
        }

        public void Insert(Skill skill)
        {
            var sql = "Insert into Skills values (@Description)";
            _db.Execute(sql, new
            {
                @Description = skill.Description
            });
        }

        public void Update(Skill skill)
        {
            var sql = "Update Skills set Description=@Description where ID=@ID";
            _db.Execute(sql, new
            {
                @Description = skill.Description,
                @ID = skill.ID
            });
        }
    }
}
