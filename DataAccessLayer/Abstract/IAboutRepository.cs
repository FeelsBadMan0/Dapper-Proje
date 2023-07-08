using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IAboutRepository
    {
        List<About> GetAll();
        About GetById(int id);
        void Insert(About about);
        void Update(About about);
        void Delete(About about);


    }
}
