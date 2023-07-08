using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class VisitorManeger : IVisitorRepository
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorManeger(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public void AdminInsert(string username, string mail, string password, string role)
        {
            _visitorRepository.AdminInsert(username, mail, password, role);
        }

        public void Delete(Visitor visitor)
        {
            _visitorRepository.Delete(visitor);
        }

        public List<Visitor> GetAll()
        {
            return _visitorRepository.GetAll();
        }

        public Visitor GetById(int id)
        {
            return _visitorRepository.GetById(id);
        }

        public Visitor GetByMail(string mail)
        {
            return _visitorRepository.GetByMail(mail);
        }

        public Visitor GetByRole(string userName)
        {
            return _visitorRepository.GetByRole(userName);
        }

        public Visitor GetByUser(string userName, string password)
        {
            return _visitorRepository.GetByUser(userName, password);
        }

        public Visitor GetByUserName(string userName)
        {
            return _visitorRepository.GetByUserName(userName);
        }

        public void Insert(string username, string mail, string password)
        {
            _visitorRepository.Insert(username, mail, password);
        }

        public void Update(string username, string mail, string role, int id)
        {
            _visitorRepository.Update(username, mail, role, id);
        }

        public void UpdatePassword(string password, string mail)
        {
            _visitorRepository.UpdatePassword(password, mail);
        }
    }
}
