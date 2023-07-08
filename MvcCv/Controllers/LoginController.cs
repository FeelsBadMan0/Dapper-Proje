using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Dapper;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcCv.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        VisitorManeger visitor = new VisitorManeger(new DpVisitorRepository());


        // GET: Login

        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Visitor p)
        {
            VisitorLoginValidator validations = new VisitorLoginValidator();
            ValidationResult results = validations.Validate(p);
            var pass = PasswordHash.MD5Create(p.Password);
            var user = visitor.GetByUser(p.Username, pass);
            var role = visitor.GetByRole(p.Username);



            if (results.IsValid)
            {
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, p.RememberMe);

                    if (p.RememberMe == true)
                    {
                        HttpCookie cookie = new HttpCookie("Visitor");
                        cookie.Value = p.Username;
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cookie);
                        if (role.Roles == "Admin" || role.Roles == "Mod")
                        {
                            return RedirectToAction("MyProfile", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Visitor");

                        }

                    }
                    else
                    {
                        if (role.Roles == "Admin" || role.Roles == "Mod")
                        {
                            Session["Visitor"] = user.Username;
                            return RedirectToAction("MyProfile", "Admin");
                        }
                        else
                        {
                            Session["Visitor"] = user.Username;
                            return RedirectToAction("Index", "Visitor");
                        }

                    }

                }
                else
                {
                    ViewBag.user = "Kullanıcı Adı veya Şifre hatalı!";
                    return View();
                }

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


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Visitor p)
        {
            VisitorAddValidation validations = new VisitorAddValidation();
            ValidationResult results = validations.Validate(p);
            string hash = PasswordHash.MD5Create(p.Password);
            var user = visitor.GetByUserName(p.Username);
            var mail = visitor.GetByMail(p.Mail);
            if (user != null)
            {
                ViewBag.user = "Bu kullanıcı ismi zaten mevcut!";
                return View();
            }
            else
            {
                if (mail != null)
                {
                    ViewBag.mail = "Bu Mail adresi zaten mevcut!";
                    return View();
                }
                else
                {
                    if (results.IsValid)
                    {

                        visitor.Insert(p.Username, p.Mail, hash);
                        ViewBag.login = "Kayıt Başarılı!";
                        ModelState.Clear();
                        return View();
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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(Visitor p)
        {
            VisitorForgotPasswordValidator validations = new VisitorForgotPasswordValidator();
            ValidationResult results = validations.Validate(p);
            var mail = visitor.GetByMail(p.Mail);
            if (results.IsValid)
            {
                if (mail != null)
                {
                    Guid random = Guid.NewGuid();
                    var sifre = random.ToString().Substring(0, 8);
                    string hash = PasswordHash.MD5Create(sifre);

                    string smptServer = "smtp.office365.com";
                    int port = 587;
                    string senderMail = "rafetseyhan50@hotmail.com";
                    string senderPassword = "aquaapakreis14";
                    string subject = "Şifre Sıfırlama";
                    string body = "Yeni geçici şifreniz :" + sifre;

                    SmtpClient client = new SmtpClient(smptServer, port);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderMail, senderPassword);
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(senderMail);
                    mailMessage.To.Add(p.Mail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    try
                    {
                        client.Send(mailMessage);
                        visitor.UpdatePassword(hash, mail.Mail);
                        ViewBag.login = "Mail başarılı bir şekilde gönderildi!";
                        return View();
                    }
                    catch
                    {
                        @ViewBag.mail = "Bir hata oluştu,tekrar deneyin!";
                        return View();
                    }



                }
                else
                {
                    ViewBag.mail = "Böyle bir mail mevcut değil";
                    return View();
                }
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

            HttpCookie cookie = Request.Cookies["Visitor"];
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