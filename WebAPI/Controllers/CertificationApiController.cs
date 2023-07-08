using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CertificationApiController : ApiController
    {
        CertificationManeger cm = new CertificationManeger(new DpCertificationRepository());
        [HttpGet]
        public IEnumerable<Certification> List()
        {
            return cm.GetAll();
        }



        [HttpPost]
        public void Add(Certification certification)
        {
            CertificationAddValidator validator = new CertificationAddValidator();
            ValidationResult results = validator.Validate(certification);
            if (results.IsValid)
            {
                cm.Insert(certification);

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
        public void Update(Certification certification)
        {
            CertificationUpdateValidator validator = new CertificationUpdateValidator();
            ValidationResult results = validator.Validate(certification);
            if (results.IsValid)
            {

                cm.Update(certification);
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
