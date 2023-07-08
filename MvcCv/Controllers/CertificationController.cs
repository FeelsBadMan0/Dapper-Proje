using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class CertificationController : Controller
    {
        CertificationManeger certification = new CertificationManeger(new DpCertificationRepository());
        // GET: Certification
        public ActionResult Index()
        {
            var values = certification.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Certification p)
        {
            CertificationAddValidator validations = new CertificationAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                certification.Insert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult Delete(Certification p)
        {
            var find = certification.GetById(p.ID);
            certification.Delete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var values = certification.GetById(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult Update(Certification p)
        {
            CertificationUpdateValidator validations = new CertificationUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                certification.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}