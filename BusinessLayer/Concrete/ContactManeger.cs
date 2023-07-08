using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContactManeger : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManeger(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void Insert(Contact contact)
        {
            _contactRepository.Insert(contact);
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }
    }
}
