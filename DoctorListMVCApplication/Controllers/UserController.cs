using Doctor_MVC_Model;
using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Login([Bind] UserLoginModel logmodel)
        {
            if (ModelState.IsValid)
            {
                var output= iuserbus.UserLogin(logmodel);
                if(output!=null)
                {
                    HttpContext.Session.SetInt32("UserID", output.UserID);
                    HttpContext.Session.SetInt32("RoleID", output.RoleID);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(logmodel);
        }
    }
}
