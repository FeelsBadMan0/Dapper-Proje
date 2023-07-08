using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ContactApiController : ApiController
    {
        ContactManeger cm = new ContactManeger(new DpContactRepository());
        [HttpGet]
        public IEnumerable<Contact> List()
        {
            return cm.GetAll();
        }

        [HttpPost]
        public void Add(Contact contact)
        {
            ContactAddValidator validator = new ContactAddValidator();
            ValidationResult results = validator.Validate(contact);
            if (results.IsValid)
            {
                cm.Insert(contact);

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
            var find = cm.GetById(id);
            cm.Delete(find);
        }

        [HttpPut]
        public void Update(Contact contact)
        {
            ContactUpdateValidator validator = new ContactUpdateValidator();
            ValidationResult results = validator.Validate(contact);
            if (results.IsValid)
            {

                cm.Update(contact);
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
