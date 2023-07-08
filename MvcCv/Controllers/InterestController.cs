using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class InterestController : Controller
    {
        InterestManeger interest = new InterestManeger(new DpInterestRepository());
        public ActionResult Index()
        {
            var values = interest.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Interest p)
        {
            InterestAddValidator validations = new InterestAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                interest.Insert(p);
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


        public ActionResult Delete(Interest p)
        {
            var find = interest.GetById(p.ID);
            interest.Delete(find);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = interest.GetById(id);
            return View(find);
        }


        [HttpPost]
        public ActionResult Update(Interest p)
        {
            InterestUpdateValidator validations = new InterestUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                interest.Update(p);
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