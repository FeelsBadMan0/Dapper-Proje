using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class InterestManeger : IInterestService
    {
        private readonly IInterestRepository _interestRepository;

        public InterestManeger(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        public void Delete(Interest interest)
        {
            _interestRepository.Delete(interest);
        }

        public List<Interest> GetAll()
        {
            return _interestRepository.GetAll();
        }

        public Interest GetById(int id)
        {
            return _interestRepository.GetById(id);
        }

        public void Insert(Interest interest)
        {
            _interestRepository.Insert(interest);
        }

        public void Update(Interest interest)
        {
            _interestRepository.Update(interest);
        }
    }
}
