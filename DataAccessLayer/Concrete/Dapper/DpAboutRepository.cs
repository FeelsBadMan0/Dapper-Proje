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
    public class DpAboutRepository : IAboutRepository
    {
        private readonly IDbConnection _db;
        public DpAboutRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }

        public void Delete(About about)
        {
            var sql = "Delete from Abouts where ID=@ID";
            _db.Execute(sql, new { @ID = about.ID });
        }

        public List<About> GetAll()
        {
            var sql = "Select * From Abouts";
            return _db.Query<About>(sql).ToList();
        }

        public About GetById(int id)
        {
            var sql = "Select * From Abouts where ID=@id";
            return _db.Query<About>(sql, new
            {
                @id = id
            }).Single();
        }

        public void Insert(About about)
        {
            var sql = "Insert into Abouts values (@Name,@Surname,@Address,@PhoneNumber,@Mail,@Description,@Image)";
            _db.Execute(sql, new
            {
                @Name = about.Name,
                @Surname = about.Surname,
                @Address = about.Address,
                @PhoneNumber = about.PhoneNumber,
                @Mail = about.Mail,
                @Description = about.Description,
                @Image = about.Image
            });

        }

        public void Update(About about)
        {
            var sql = "Update Abouts set Name=@Name, Surname=@Surname, Address=@Address,PhoneNumber=@PhoneNumber, Mail=@Mail, Description=@Description,Image=@Image where ID=@ID";
            _db.Execute(sql, about);
        }
    }
}
