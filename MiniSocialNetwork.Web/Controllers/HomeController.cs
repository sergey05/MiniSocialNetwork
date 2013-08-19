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
        private IServiceBase<User> userService;

        public HomeController(IServiceBase<User> serv)
        {
            userService = serv;
        }

        public ActionResult Index()
        {
            userService.Get();
            return null;
        }

    }
}
