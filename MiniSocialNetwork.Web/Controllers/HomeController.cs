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
            //_userService.AddNewUser(new User { Name = "Name2", Password = "Password2", Email = "ololo2@tut.by" });
            return null;
        }

    }
}
