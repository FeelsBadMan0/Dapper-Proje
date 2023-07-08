using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ExperienceApiController : ApiController
    {
        ExperienceManeger exp = new ExperienceManeger(new DpExperienceRepository());
        [HttpGet]
        public IEnumerable<Experience> List()
        {
            return exp.GetAll();
        }

        [HttpPost]
        public void Add(Experience experience)
        {
            ExperienceAddValidator validator = new ExperienceAddValidator();
            ValidationResult results = validator.Validate(experience);
            if (results.IsValid)
            {
                exp.Insert(experience);

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
            var find = exp.GetById(id);
            exp.Delete(find);
        }

        [HttpPut]
        public void Update(Experience experience)
        {
            ExperienceUpdateValidator validator = new ExperienceUpdateValidator();
            ValidationResult results = validator.Validate(experience);
            if (results.IsValid)
            {

                exp.Update(experience);
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
