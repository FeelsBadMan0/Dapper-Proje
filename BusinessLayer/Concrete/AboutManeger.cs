using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManeger : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutManeger(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public void Delete(About about)
        {
            _aboutRepository.Delete(about);
        }

        public List<About> GetAll()
        {

            return _aboutRepository.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutRepository.GetById(id);
        }

        public void Insert(About about)
        {
            _aboutRepository.Insert(about);
        }

        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }
    }
}
