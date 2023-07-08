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
    public class DpCertificationRepository : ICertificationRepository
    {
        private readonly IDbConnection _db;
        public DpCertificationRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Certification certification)
        {
            var sql = "Delete From Certifications Where ID=@ID";
            _db.Execute(sql, new { certification.ID });
        }

        public List<Certification> GetAll()
        {
            var sql = "Select * From Certifications";
            return _db.Query<Certification>(sql).ToList();
        }

        public Certification GetById(int id)
        {
            var sql = "Select * from Certifications where ID=@ID";
            return _db.Query<Certification>(sql, new
            {
                @ID = id
            }).Single();
        }

        public void Insert(Certification certification)
        {
            var sql = "Insert into Certifications values(@Desc)";
            _db.Execute(sql, new
            {
                @Desc = certification.Description

            });
        }

        public void Update(Certification certification)
        {
            var sql = "Update Certifications set Description=@Description where ID=@ID";
            _db.Execute(sql, new
            {
                @Description = certification.Description,
                @ID = certification.ID
            });
        }
    }
}
