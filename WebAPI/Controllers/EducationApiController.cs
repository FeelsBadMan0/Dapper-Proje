using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class EducationApiController : ApiController
    {
        EducationManeger edc = new EducationManeger(new DpEducationRepository());
        [HttpGet]
        public IEnumerable<Education> List()
        {
            return edc.GetAll();
        }

        [HttpPost]
        public void Add(Education education)
        {
            EducationAddValidator validator = new EducationAddValidator();
            ValidationResult results = validator.Validate(education);
            if (results.IsValid)
            {
                edc.Insert(education);

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
            var find = edc.GetById(id);
            edc.Delete(find);
        }

        [HttpPut]
        public void Update(Education education)
        {
            EducationUpdateValidator validator = new EducationUpdateValidator();
            ValidationResult results = validator.Validate(education);
            if (results.IsValid)
            {

                edc.Update(education);
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
