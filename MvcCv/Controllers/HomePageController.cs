using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Dapper;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {

        // GET: HomePage
        AboutManeger about = new AboutManeger(new DpAboutRepository());

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.v1 = about.GetAll().Select(x => x.Name).First();
            ViewBag.v2 = about.GetAll().Select(y => y.Surname).First();
            ViewBag.v3 = about.GetAll().Select(z => z.Image).First();
            return View();
        }


        [ChildActionOnly]
        public PartialViewResult AboutPage()
        {
            var aboutList = about.GetAll();
            return PartialView(aboutList);
        }
        [ChildActionOnly]
        public PartialViewResult ExperiencePage()
        {
            ExperienceManeger experience = new ExperienceManeger(new DpExperienceRepository());
            var experienceList = experience.GetAll();
            return PartialView(experienceList);
        }
        [ChildActionOnly]
        public PartialViewResult EducationPage()
        {
            EducationManeger education = new EducationManeger(new DpEducationRepository());
            var educationList = education.GetAll();
            return PartialView(educationList);
        }
        [ChildActionOnly]
        public PartialViewResult SkillPage()
        {
            SkillManeger skill = new SkillManeger(new DpSkillRepository());
            var skillList = skill.GetAll();
            return PartialView(skillList);
        }
        [ChildActionOnly]
        public PartialViewResult InterestPage()
        {
            InterestManeger interest = new InterestManeger(new DpInterestRepository());
            var interestList = interest.GetAll();
            return PartialView(interestList);
        }
        [ChildActionOnly]
        public PartialViewResult CertificationPage()
        {
            CertificationManeger certification = new CertificationManeger(new DpCertificationRepository());
            var certificationList = certification.GetAll();
            return PartialView(certificationList);
        }


    }
}