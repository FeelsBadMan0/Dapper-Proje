using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
