using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IVisitorService
    {
        List<Visitor> GetAll();
        Visitor GetById(int id);
        void Insert(string username, string mail, string password);
        void Update(string username, string mail, string role, int id);
        void Delete(Visitor visitor);
        Visitor GetByUserName(string userName);
        Visitor GetByUser(string userName, string password);
        Visitor GetByMail(string mail);
        void UpdatePassword(string password, string mail);
        Visitor GetByRole(string userName);
        void AdminInsert(string username, string mail, string password, string role);
    }
}
