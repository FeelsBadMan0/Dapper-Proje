using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class EducationManeger : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationManeger(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public void Delete(Education education)
        {
            _educationRepository.Delete(education);
        }

        public List<Education> GetAll()
        {
            return _educationRepository.GetAll();
        }

        public Education GetById(int id)
        {
            return _educationRepository.GetById(id);
        }

        public void Insert(Education education)
        {
            _educationRepository.Insert(education);
        }

        public void Update(Education education)
        {
            _educationRepository.Update(education);
        }
    }
}
