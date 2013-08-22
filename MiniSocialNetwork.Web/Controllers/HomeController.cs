using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModels;
using Services;

namespace MiniSocialNetwork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdministrationService _adminService;

        public HomeController(IUserService userService,IAdministrationService adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            _adminService.MakeAdmin(new Guid("5a866af4-c564-4eda-95c8-fdb8bc64deb3"));
            return null;
        }

    }
}
