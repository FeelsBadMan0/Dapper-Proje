using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IEducationService
    {
        List<Education> GetAll();
        Education GetById(int id);
        void Insert(Education education);
        void Update(Education education);
        void Delete(Education education);
    }
}
