using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AdminManeger : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminManeger(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void ChangePassword(Admin admin)
        {
            _adminRepository.ChangePassword(admin);
        }

        public void Delete(Admin admin)
        {
            _adminRepository.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetByAdmin(string userName, string password)
        {
            return _adminRepository.GetByAdmin(userName, password);
        }

        public Admin GetById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public Admin GetByUserName(string userName)
        {
            return _adminRepository.GetByUserName(userName);
        }

        public void Insert(Admin admin)
        {
            _adminRepository.Insert(admin);
        }

        public void Update(Admin admin)
        {
            _adminRepository.Update(admin);
        }
    }
}
