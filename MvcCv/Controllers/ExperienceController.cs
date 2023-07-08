using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class ExperienceController : Controller
    {
        ExperienceManeger experience = new ExperienceManeger(new DpExperienceRepository());
        public ActionResult Index()
        {
            var values = experience.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Experience p)
        {
            ExperienceAddValidator validations = new ExperienceAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                experience.Insert(p);
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

        public ActionResult Delete(Experience p)
        {
            var find = experience.GetById(p.ID);
            experience.Delete(find);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = experience.GetById(id);
            return View(find);
        }



        [HttpPost]
        public ActionResult Update(Experience p)
        {
            ExperienceUpdateValidator validations = new ExperienceUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                experience.Update(p);
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