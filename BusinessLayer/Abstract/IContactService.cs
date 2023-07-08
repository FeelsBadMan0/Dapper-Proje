using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
