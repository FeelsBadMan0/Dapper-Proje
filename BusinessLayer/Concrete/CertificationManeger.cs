using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CertificationManeger : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationManeger(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        public void Delete(Certification certification)
        {
            _certificationRepository.Delete(certification);
        }

        public List<Certification> GetAll()
        {
            return _certificationRepository.GetAll();
        }

        public Certification GetById(int id)
        {
            return _certificationRepository.GetById(id);
        }

        public void Insert(Certification certification)
        {
            _certificationRepository.Insert(certification);
        }

        public void Update(Certification certification)
        {
            _certificationRepository.Update(certification);
        }
    }
}
