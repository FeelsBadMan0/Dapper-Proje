using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetAll();
        Skill GetById(int id);
        void Insert(Skill skill);
        void Update(Skill skill);
        void Delete(Skill skill);
    }
}
