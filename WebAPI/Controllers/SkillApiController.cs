using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SkillApiController : ApiController
    {
        SkillManeger skl = new SkillManeger(new DpSkillRepository());
        [HttpGet]
        public IEnumerable<Skill> List()
        {
            return skl.GetAll();
        }

        [HttpPost]
        public void Add(Skill skill)
        {
            SkillAddValidator validator = new SkillAddValidator();
            ValidationResult results = validator.Validate(skill);
            if (results.IsValid)
            {
                skl.Insert(skill);

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
            var find = skl.GetById(id);
            skl.Delete(find);
        }

        [HttpPut]
        public void Update(Skill skill)
        {
            SkillUpdateValidator validator = new SkillUpdateValidator();
            ValidationResult results = validator.Validate(skill);
            if (results.IsValid)
            {

                skl.Update(skill);
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
