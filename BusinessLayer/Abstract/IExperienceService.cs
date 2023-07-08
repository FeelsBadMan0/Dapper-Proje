using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IExperienceService
    {
        List<Experience> GetAll();
        Experience GetById(int id);
        void Insert(Experience experience);
        void Update(Experience experience);
        void Delete(Experience experience);
    }
}
