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
    public class DpAdminRepository : IAdminRepository
    {
        private readonly IDbConnection _db;
        public DpAdminRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }

        public void ChangePassword(Admin admin)
        {
            var sql = "Update Admins set Password=@Password where ID=@ID";
            _db.Execute(sql, new
            {
                @Password = admin.Password,
                @ID = admin.ID
            });
        }

        public void Delete(Admin admin)
        {
            var sql = "Delete from Admins where ID=@ID";
            _db.Execute(sql, new
            {
                @ID = admin.ID
            });
        }

        public List<Admin> GetAll()
        {
            var sql = "Select * from Admins";
            return _db.Query<Admin>(sql).ToList();
        }

        public Admin GetByAdmin(string userName, string password)
        {
            var sql = "Select * from Admins where UserName=@Username and Password = @Password";
            return _db.Query<Admin>(sql, new
            {
                @Username = userName,
                @Password = password
            }).FirstOrDefault();
        }

        public Admin GetById(int id)
        {
            var sql = "Select * from Admins where ID=@ID";
            return _db.Query<Admin>(sql, new
            {
                @ID = id,
            }).FirstOrDefault();
        }

        public Admin GetByUserName(string userName)
        {
            var sql = "Select * from Admins where UserName=@Username";
            return _db.Query<Admin>(sql, new
            {
                @Username = userName
            }).FirstOrDefault();
        }

        public void Insert(Admin admin)
        {
            var sql = "Insert into Admins values(@Username,@Password,@AdminRole)";
            _db.Execute(sql, new
            {
                @Username = admin.UserName,
                @Password = admin.Password,
                @AdminRole = admin.AdminRoles
            });
        }

        public void Update(Admin admin)
        {
            var sql = "Update Admins set UserName=@Username,Password=@Password, AdminRoles=@AdminRole where ID=@ID";
            _db.Execute(sql, new
            {
                @Username = admin.UserName,
                @Password = admin.Password,
                @AdminRole = admin.AdminRoles,
                @ID = admin.ID
            });
        }
    }
}
