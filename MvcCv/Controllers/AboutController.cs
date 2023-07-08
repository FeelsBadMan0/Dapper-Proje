using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class AboutController : Controller
    {
        AboutManeger about = new AboutManeger(new DpAboutRepository());

        // GET: About
        public ActionResult Index()
        {
            var list = about.GetAll();

            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About p)
        {
            AboutAddValidator validations = new AboutAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                about.Insert(p);
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

        public ActionResult Delete(About p)
        {
            var find = about.GetById(p.ID);
            about.Delete(find);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = about.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(About p)
        {
            AboutUpdateValidator validations = new AboutUpdateValidator();
            ValidationResult result = validations.Validate(p);
            if (result.IsValid)
            {
                about.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
        }
    }
}