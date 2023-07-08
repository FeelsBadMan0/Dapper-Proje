using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IInterestService
    {
        List<Interest> GetAll();
        Interest GetById(int id);
        void Insert(Interest interest);
        void Update(Interest interest);
        void Delete(Interest interest);
    }
}
