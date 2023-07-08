using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class ContactController : Controller
    {
        ContactManeger contact = new ContactManeger(new DpContactRepository());
        // GET: Contact
        public ActionResult Index()
        {
            var values = contact.GetAll();
            return View(values);
        }

        public ActionResult Delete(Contact p)
        {
            var find = contact.GetById(p.ID);
            contact.Delete(find);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var find = contact.GetById(id);
            return View(find);
        }

        [HttpPost]
        public ActionResult Update(Contact p)
        {
            ContactUpdateValidator validations = new ContactUpdateValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                contact.Update(p);
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