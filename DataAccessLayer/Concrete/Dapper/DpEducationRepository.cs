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
    public class DpEducationRepository : IEducationRepository
    {
        private readonly IDbConnection _db;
        public DpEducationRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Education education)
        {
            var sql = "Delete from Educations where ID=@ID";
            _db.Execute(sql, new { education.ID });

        }

        public List<Education> GetAll()
        {
            var sql = "Select * from Educations";
            return _db.Query<Education>(sql).ToList();
        }

        public Education GetById(int id)
        {
            var sql = "Select * from Educations where ID=@ID";
            return _db.Query<Education>(sql, new { @ID = id }).Single();
        }

        public void Insert(Education education)
        {
            var sql = "Insert into Educations values(@Title,@SubTitle,@Description,@GNOT,@Date)";
            _db.Execute(sql, new
            {
                @Title = education.Title,
                @SubTitle = education.SubTitle,
                @Description = education.Description,
                @GNOT = education.GNOT,
                @Date = education.Date
            });
        }

        public void Update(Education education)
        {
            var sql = "Update Educations set Title=@Title, SubTitle=@SubTitle, Description=@Description, GNOT=@GNOT,Date=@Date where ID=@ID";
            _db.Execute(sql, new
            {
                @Title = education.Title,
                @SubTitle = education.SubTitle,
                @Description = education.Description,
                @GNOT = education.GNOT,
                @Date = education.Date,
                @ID = education.ID
            });
        }
    }
}
