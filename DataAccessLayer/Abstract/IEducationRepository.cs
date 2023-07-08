using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IEducationRepository
    {
        List<Education> GetAll();
        Education GetById(int id);
        void Insert(Education education);
        void Update(Education education);
        void Delete(Education education);
    }
}
