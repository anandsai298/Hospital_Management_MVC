using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorListMVCApplication.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientBusiness ipatbus;
        public PatientController(IPatientBusiness ipatbus)
        {
            this.ipatbus = ipatbus;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PatientDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PatientDetails([Bind] PatientModel patmodel)
        {
            int UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (ModelState.IsValid)
            {
                ipatbus.PatientDetails(patmodel);
                return RedirectToAction("Index", "Home");
            }
            return View(patmodel);
        }
        [HttpGet]
        public IActionResult GetAllPatientData()
        {
            List<PatientModel> list = new List<PatientModel>();
            list = ipatbus.GetAllPatientDetails().ToList();
            int roleid = (int)HttpContext.Session.GetInt32("RoleID");
            if (roleid == 3)
            {
                return View(list);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetAllPatientDetails_UserID()
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                var op = ipatbus.GetAllPatientDetails_UserID(UserID);
                return View(op);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
