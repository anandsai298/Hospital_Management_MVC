using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorListMVCApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBusiness adminbus;
        public AdminController(IAdminBusiness adminbus)
        {
            this.adminbus = adminbus;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllUserData()
        {
            List<UserRegistrationModel> model = new List<UserRegistrationModel>();
            model = adminbus.GetAllUserData().ToList();
            int roleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (roleID == 1)
            {
                return View(model);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
