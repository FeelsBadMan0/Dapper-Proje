using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcCv.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin,Mod")]
    public class AdminController : Controller
    {
        VisitorManeger visitorManeger = new VisitorManeger(new DpVisitorRepository());
        // GET: Admin

        public ActionResult MyProfile()
        {
            string userName = Request.Cookies["Visitor"]?.Value;
            if (userName != null)
            {
                var result = visitorManeger.GetByUserName(userName);
                return View(result);
            }
            else
            {
                var userNameSession = (string)Session["Visitor"];
                var degerler = visitorManeger.GetByUserName(userNameSession);
                return View(degerler);
            }

        }
        [HttpPost]
        public ActionResult MyProfile(Visitor visitor)
        {
            VisitorUpdateValidator validator = new VisitorUpdateValidator();
            ValidationResult results = validator.Validate(visitor);
            var hash = PasswordHash.MD5Create(visitor.Password);
            if (results.IsValid)
            {
                visitorManeger.UpdatePassword(hash, visitor.Mail);
                return RedirectToAction("Logout");
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
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            var results = visitorManeger.GetAll();
            return View(results);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.Roles = new SelectList(new[]
            {
                new SelectListItem{Text="Admin",Value="Admin"},
                new SelectListItem{ Text="Mod",Value="Mod"},
                new SelectListItem{ Text="User",Value="User"}
            }, "Value", "Text");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(Visitor visitor)
        {
            ViewBag.Roles = new SelectList(new[]
            {
                new SelectListItem{Text="Admin",Value="Admin"},
                new SelectListItem{ Text="Mod",Value="Mod"},
                new SelectListItem{ Text="User",Value="User"}
            }, "Value", "Text");

            VisitorAdminAddValidator validations = new VisitorAdminAddValidator();
            ValidationResult results = validations.Validate(visitor);
            var hash = PasswordHash.MD5Create(visitor.Password);
            if (results.IsValid)
            {
                visitorManeger.AdminInsert(visitor.Username, visitor.Mail, hash, visitor.Roles);
                return RedirectToAction("Admin");
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

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var find = visitorManeger.GetById(id);
            visitorManeger.Delete(find);
            return RedirectToAction("Admin");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            ViewBag.Roles = new SelectList(new[]
            {
                new SelectListItem{Text="Admin",Value="Admin"},
                new SelectListItem{ Text="Mod",Value="Mod"},
                new SelectListItem{ Text="User",Value="User"}
            }, "Value", "Text");

            var find = visitorManeger.GetById(id);
            return View(find);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(Visitor visitor)
        {
            ViewBag.Roles = new SelectList(new[]
            {
                new SelectListItem{Text="Admin",Value="Admin"},
                new SelectListItem{ Text="Mod",Value="Mod"},
                new SelectListItem{ Text="User",Value="User"}
            }, "Value", "Text");

            VisitorAdminUpdateValidator validations = new VisitorAdminUpdateValidator();
            ValidationResult results = validations.Validate(visitor);
            if (results.IsValid)
            {
                visitorManeger.Update(visitor.Username, visitor.Mail, visitor.Roles, visitor.ID);
                return RedirectToAction("Admin");
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


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            HttpCookie cookie = Request.Cookies["Username"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);

            }
            else
            {
                Session.Clear();
                Session.Abandon();
            }
            return RedirectToAction("Login", "Login");

        }
    }
}