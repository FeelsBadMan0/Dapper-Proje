using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ISkillRepository
    {
        List<Skill> GetAll();
        Skill GetById(int id);
        void Insert(Skill skill);
        void Update(Skill skill);
        void Delete(Skill skill);
    }
}
