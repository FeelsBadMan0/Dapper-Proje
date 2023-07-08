using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class InterestApiController : ApiController
    {
        InterestManeger intr = new InterestManeger(new DpInterestRepository());
        [HttpGet]
        public IEnumerable<Interest> List()
        {
            return intr.GetAll();
        }

        [HttpPost]
        public void Add(Interest interest)
        {
            InterestAddValidator validator = new InterestAddValidator();
            ValidationResult results = validator.Validate(interest);
            if (results.IsValid)
            {
                intr.Insert(interest);

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
            var find = intr.GetById(id);
            intr.Delete(find);
        }

        [HttpPut]
        public void Update(Interest interest)
        {
            InterestUpdateValidator validator = new InterestUpdateValidator();
            ValidationResult results = validator.Validate(interest);
            if (results.IsValid)
            {

                intr.Update(interest);
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
