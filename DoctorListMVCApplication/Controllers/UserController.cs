using Doctor_MVC_Model;
using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using Microsoft.AspNetCore.Mvc;

namespace DoctorListMVCApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBusiness iuserbus;
        public UserController(IUserBusiness iuserbus)
        {
            this.iuserbus = iuserbus;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind] UserRegistrationModel regmodel)
        {
            if (ModelState.IsValid)
            {
                iuserbus.RegisterUser(regmodel);
                return RedirectToAction("Index","Home");
            }
            return View(regmodel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind] UserLoginModel logmodel, string emailID, string password)
        {
            if (ModelState.IsValid)
            {
                iuserbus.UserLogin(logmodel, emailID, password);
                return RedirectToAction("Index", "Home");
            }
            return View(logmodel);
        }
    }
}
