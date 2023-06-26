using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorListMVCApplication.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorBusiness idocbus;
        public DoctorController(IDoctorBusiness idocbus)
        {
            this.idocbus = idocbus;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DoctorDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoctorDetails([Bind] DoctorModel docmodel)
        {
            int UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (ModelState.IsValid)
            {
                var op=idocbus.DoctorDetails(docmodel);
                if(op!=null)
                {
                    HttpContext.Session.SetInt32("DoctorID", op.DoctorID);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(docmodel);
        }
        [HttpGet]
        public IActionResult GetAllDoctorData()
        {
            int roleid = (int)HttpContext.Session.GetInt32("RoleID");
            if (roleid == 3)
            {
                List<DoctorModel> list = new List<DoctorModel>();
                list = idocbus.GetAllDoctorDetails().ToList();
                foreach(DoctorModel item in list)
                {
                    int DoctotID = item.DoctorID;
                    HttpContext.Session.SetInt32("DoctorID", DoctotID);
                }
                return View(list);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetAllDoctorDetails_UserID()
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                var op = idocbus.GetAllDoctorDetails_UserID(UserID);
                if(op!=null)
                {
                    HttpContext.Session.SetInt32("DoctorID", op.DoctorID);
                }
                return View(op);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetAllDoctorDetails_DoctorID(int DoctorID)
        {
            if (ModelState.IsValid)
            {
                DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                var op = idocbus.GetAllDoctorDetails_DoctorID(DoctorID);
                return View(op);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
