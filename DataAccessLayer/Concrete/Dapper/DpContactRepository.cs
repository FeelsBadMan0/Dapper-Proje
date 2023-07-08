using Dapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Concrete.Dapper
{
    public class DpContactRepository : IContactRepository
    {
        private readonly IDbConnection _db;
        public DpContactRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _db = new SqlConnection(connectionString);
        }
        public void Delete(Contact contact)
        {
            var sql = "Delete from Contacts where ID=@ID";
            _db.Execute(sql, new { contact.ID });
        }

        public List<Contact> GetAll()
        {
            var sql = "Select * from Contacts";
            return _db.Query<Contact>(sql).ToList();
        }

        public Contact GetById(int id)
        {
            var sql = "Select * from Contacts where ID=@ID";
            return _db.Query<Contact>(sql, new
            {
                @ID = id
            }).Single();
        }

        public void Insert(Contact contact)
        {
            var sql = "Insert into Contacts values(@NameSurname,@Mail,@Subject,@Message,@Date)";
            _db.Execute(sql, new
            {
                @NameSurname = contact.NameSurname,
                @Mail = contact.Mail,
                @Subject = contact.Subject,
                @Message = contact.Message,
                @Date = DateTime.Now
            });
        }

        public void Update(Contact contact)
        {
            var sql = "Update Contacts set NameSurname=@NameSurname, Mail=@Mail, Subject=@Subject,Message=@Message,Date=@Date where ID=@ID";
            _db.Execute(sql, new
            {
                @NameSurname = contact.NameSurname,
                @Mail = contact.Mail,
                @Subject = contact.Subject,
                @Message = contact.Message,
                @Date = DateTime.Now,
                @ID = contact.ID
            });
        }
    }
}
