using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SkillManeger : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillManeger(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public void Delete(Skill skill)
        {
            _skillRepository.Delete(skill);
        }

        public List<Skill> GetAll()
        {
            return _skillRepository.GetAll();
        }

        public Skill GetById(int id)
        {
            return _skillRepository.GetById(id);
        }

        public void Insert(Skill skill)
        {
            _skillRepository.Insert(skill);
        }

        public void Update(Skill skill)
        {
            _skillRepository.Update(skill);
        }
    }
}
