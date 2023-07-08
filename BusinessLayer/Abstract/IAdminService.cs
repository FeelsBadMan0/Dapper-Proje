using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        void Insert(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
        Admin GetByUserName(string userName);
        Admin GetByAdmin(string userName, string password);
        void ChangePassword(Admin admin);
    }
}
