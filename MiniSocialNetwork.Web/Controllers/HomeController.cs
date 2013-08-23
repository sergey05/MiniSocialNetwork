using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DomainModels;
using Services;

namespace MiniSocialNetwork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdministrationService _adminService;
        private readonly IMessageService _messageService;

        public HomeController(IUserService userService, IAdministrationService adminService, IMessageService messageService)
        {
            _userService = userService;
            _adminService = adminService;
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            //_userService.AddNewUser(new User() {Name = "Peter", Password = "Pass", Email = "ser@tut.by"});
            //_userService.AddNewUser(new User() {Name = "Peter", Password = "Pass", Email = "ser2@tut.by"});
            //_userService.AddNewUser(new User() {Name = "Peter", Password = "Pass", Email = "ser3@tut.by"});
            //var sender = _userService.Get().First();
            //var recipient1 = _userService.Get().ElementAt(1);
            //var recipient2 = _userService.Get().ElementAt(2);
            //var recipients = new List<User> { recipient1, recipient2 };
            //var m = new Message {Content = "some content",Subject = "ololo"};
            //_messageService.AddNewMessage(m, sender, recipients);
            var user = _userService.Get().First();
            return null;
        }

        public string Users()
        {
            var users = _userService.Get();
            string str = "";
            foreach (var user in users)
            {
                str += "Name: " + user.Name + ", email: " + user.Email;
                str += "\r\n";
            }
            return str;
        }

        public string Messages()
        {
            var messages = _messageService.Get();
            string str = "";
            foreach (var message in messages)
            {
                str += "Content: " + message.Content + ", Subject: " + message.Subject;
                str += "\r\n";
            }
            return str;
        }
    }
}
