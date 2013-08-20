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
            userService.Insert(new User(){Name="Name",Password = "Password",Email = "ololo@tut.by",Foto = new byte[]{1,2,3,4,7,6}});
            userService.CommitChanges();
            return null;
        }

    }
}
