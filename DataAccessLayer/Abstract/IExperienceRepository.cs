using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IExperienceRepository
    {
        List<Experience> GetAll();
        Experience GetById(int id);
        void Insert(Experience experience);
        void Update(Experience experience);
        void Delete(Experience experience);
    }
}
