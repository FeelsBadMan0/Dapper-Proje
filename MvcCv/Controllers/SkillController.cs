using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class SkillController : Controller
    {
        SkillManeger skill = new SkillManeger(new DpSkillRepository());
        public ActionResult Index()
        {
            var values = skill.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Skill p)
        {
            SkillAddValidator validations = new SkillAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                skill.Insert(p);
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

        public ActionResult Delete(Skill p)
        {
            var find = skill.GetById(p.ID);
            skill.Delete(find);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = skill.GetById(id);
            return View(find);
        }



        [HttpPost]
        public ActionResult Update(Skill p)
        {
            SkillUpdateValidator validations = new SkillUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                skill.Update(p);
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