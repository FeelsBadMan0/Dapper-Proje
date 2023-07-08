using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcCv.Models;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class VisitorController : Controller
    {
        VisitorManeger visitor = new VisitorManeger(new DpVisitorRepository());


        [HttpGet]
        public ActionResult Index()
        {
            string visitorUserName = Request.Cookies["Visitor"]?.Value;
            if (visitorUserName != null)
            {
                var result = visitor.GetByUserName(visitorUserName);
                ViewBag.u = visitorUserName;
                return View(result);
            }
            else
            {
                var userName = (string)Session["Visitor"];
                var degerler = visitor.GetByUserName(userName);
                ViewBag.u = userName;
                return View(degerler);
            }


        }

        [HttpPost]
        public ActionResult Index(Visitor p)
        {
            VisitorUpdateValidator validations = new VisitorUpdateValidator();
            ValidationResult results = validations.Validate(p);
            string hash = PasswordHash.MD5Create(p.Password);
            if (results.IsValid)
            {
                visitor.UpdatePassword(hash, p.Mail);
                return RedirectToAction("Logout", "Login");
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

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact p)
        {
            ContactManeger contact = new ContactManeger(new DpContactRepository());
            ContactAddValidator validations = new ContactAddValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                contact.Insert(p);
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