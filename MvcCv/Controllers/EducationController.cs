using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class EducationController : Controller
    {
        EducationManeger education = new EducationManeger(new DpEducationRepository());
        public ActionResult Index()
        {
            var values = education.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Education p)
        {
            EducationAddValidator validations = new EducationAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                education.Insert(p);
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

        public ActionResult Delete(Education p)
        {
            var find = education.GetById(p.ID);
            education.Delete(find);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = education.GetById(id);
            return View(find);
        }

        [HttpPost]
        public ActionResult Update(Education p)
        {
            EducationUpdateValidator validations = new EducationUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                education.Update(p);
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