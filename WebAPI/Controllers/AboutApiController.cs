using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AboutApiController : ApiController
    {
        AboutManeger abm = new AboutManeger(new DpAboutRepository());
        [HttpGet]
        public IEnumerable<About> List()
        {
            return abm.GetAll();
        }

        [HttpPost]
        public void Add(About about)
        {
            AboutAddValidator validator = new AboutAddValidator();
            ValidationResult results = validator.Validate(about);
            if (results.IsValid)
            {
                abm.Insert(about);

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

        }

        [HttpDelete]
        public void Delete(int id)
        {
            var find = abm.GetById(id);
            abm.Delete(find);
        }

        [HttpPut]
        public void Update(About about)
        {
            AboutUpdateValidator validator = new AboutUpdateValidator();
            ValidationResult results = validator.Validate(about);
            if (results.IsValid)
            {

                abm.Update(about);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
        }
    }
}
