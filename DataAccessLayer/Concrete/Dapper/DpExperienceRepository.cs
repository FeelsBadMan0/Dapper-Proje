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
    public class DpExperienceRepository : IExperienceRepository
    {
        private readonly IDbConnection _db;
        public DpExperienceRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Experience experience)
        {
            var sql = "Delete from Experiences where ID=@ID";
            _db.Execute(sql, new { experience.ID });
        }

        public List<Experience> GetAll()
        {
            var sql = "Select * from Experiences";
            return _db.Query<Experience>(sql).ToList();
        }

        public Experience GetById(int id)
        {
            var sql = "Select * from Experiences where ID=@ID";
            return _db.Query<Experience>(sql, new { @ID = id }).Single();
        }

        public void Insert(Experience experience)
        {
            var sql = "Insert into Experiences values(@Title,@SubTitle,@Description,@Date)";
            _db.Execute(sql, new
            {
                @Title = experience.Title,
                @SubTitle = experience.SubTitle,
                @Description = experience.Description,
                @Date = experience.Date,

            });
        }

        public void Update(Experience experience)
        {
            var sql = "Update Experiences set Title=@Title,SubTitle=@SubTitle,Description=@Description,Date=@Date where ID=@ID";
            _db.Execute(sql, new
            {
                @Title = experience.Title,
                @SubTitle = experience.SubTitle,
                @Description = experience.Description,
                @Date = experience.Date,
                @ID = experience.ID
            });
        }
    }
}
