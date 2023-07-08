using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IInterestRepository
    {
        List<Interest> GetAll();
        Interest GetById(int id);
        void Insert(Interest interest);
        void Update(Interest interest);
        void Delete(Interest interest);
    }
}
