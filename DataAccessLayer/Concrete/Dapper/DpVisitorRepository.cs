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
    public class DpVisitorRepository : IVisitorRepository
    {
        private readonly IDbConnection _db;

        public DpVisitorRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }

        public void AdminInsert(string username, string mail, string password, string role)
        {
            var sql = "Insert into Visitors values (@Username,@Mail,@Password,@Roles)";
            _db.Execute(sql, new
            {
                @Username = username,
                @Mail = mail,
                @Password = password,
                @Roles = role
            });
        }

        public void Delete(Visitor visitor)
        {
            var sql = "Delete from Visitors where ID=@ID";
            _db.Execute(sql, new
            {
                @ID = visitor.ID
            });
        }

        public List<Visitor> GetAll()
        {
            var sql = "Select * from Visitors";
            return _db.Query<Visitor>(sql).ToList();
        }

        public Visitor GetById(int id)
        {
            var sql = "Select * from Visitors where ID=@ID";
            return _db.Query<Visitor>(sql, new
            {
                @ID = id
            }).Single();
        }

        public Visitor GetByMail(string mail)
        {
            var sql = "Select * from Visitors where Mail=@Mail";
            return _db.Query<Visitor>(sql, new
            {
                @Mail = mail
            }).FirstOrDefault();
        }

        public Visitor GetByRole(string userName)
        {
            var sql = "Select Roles from Visitors where Username=@Username";
            return _db.Query<Visitor>(sql, new
            {
                @Username = userName
            }).FirstOrDefault();
        }

        public Visitor GetByUser(string userName, string password)
        {
            var sql = "Select * from Visitors where Username=@Username and Password=@Password";
            return _db.Query<Visitor>(sql, new
            {
                @UserName = userName,
                @Password = password
            }).FirstOrDefault();
        }

        public Visitor GetByUserName(string userName)
        {
            var sql = "Select * from Visitors where Username=@Username";
            return _db.Query<Visitor>(sql, new { @Username = userName }).FirstOrDefault();
        }

        public void Insert(string username, string mail, string password)
        {
            var sql = "Insert into Visitors values(@Username,@Mail,@Password,@Roles)";
            _db.Execute(sql, new
            {
                @Username = username,
                @Password = password,
                @Mail = mail,
                @Roles = "User"
            });
        }

        public void Update(string username, string mail, string role, int id)
        {
            var sql = "Update Visitors set Username=@Username, Mail=@Mail,Roles=@Roles where ID=@ID";
            _db.Execute(sql, new
            {
                @Username = username,
                @Mail = mail,
                @Roles = role,
                @ID = id

            });
        }

        public void UpdatePassword(string password, string mail)
        {
            var sql = "Update Visitors set Password = @Password where Mail= @Mail";
            _db.Execute(sql, new
            {
                @Password = password,
                @Mail = mail
            });
        }
    }
}
