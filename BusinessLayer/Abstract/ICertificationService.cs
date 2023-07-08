using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICertificationService
    {
        List<Certification> GetAll();
        Certification GetById(int id);
        void Insert(Certification certification);
        void Update(Certification certification);
        void Delete(Certification certification);
    }
}
