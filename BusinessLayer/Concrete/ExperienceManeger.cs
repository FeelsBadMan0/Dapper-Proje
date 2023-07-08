using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ExperienceManeger : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceManeger(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public void Delete(Experience experience)
        {
            _experienceRepository.Delete(experience);
        }

        public List<Experience> GetAll()
        {
            return _experienceRepository.GetAll();
        }

        public Experience GetById(int id)
        {
            return _experienceRepository.GetById(id);
        }

        public void Insert(Experience experience)
        {
            _experienceRepository.Insert(experience);
        }

        public void Update(Experience experience)
        {
            _experienceRepository.Update(experience);
        }
    }
}
