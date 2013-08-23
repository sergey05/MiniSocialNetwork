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
        private readonly IPostService _postService;

        public HomeController(IUserService userService, IAdministrationService adminService, IMessageService messageService,IPostService postService)
        {
            _userService = userService;
            _adminService = adminService;
            _messageService = messageService;
            _postService = postService;
        }

        public ActionResult Index()
        {
            //_userService.AddNewUser(new User() { Name = "Peter Rumbler", Password = "Rumbler", Email = "Peter.Rumbler@itechart-group.by" });
            //_userService.AddNewUser(new User() { Name = "Chisty Gullion", Password = "Gullion", Email = "Chisty.Gullion@itechart-group.by" });
            //_userService.AddNewUser(new User() { Name = "David Wadleton", Password = "Wadleton", Email = "David.Wadleton@itechart-group.by" });
            var poster = _userService.Get().Last();
            _postService.AddNewPost(new Post{Content = "My first post",Title = "first post title"}, poster);
            _postService.Repost(_postService.Get().Last(),_userService.Get().Last());
            
            //var recipient1 = _userService.Get().ElementAt(1);
            //var recipient2 = _userService.Get().ElementAt(2);
            //var recipients = new List<User> { recipient1, recipient2 };
            //var m = new Message { Content = "some content", Subject = "ololo" };
            //_messageService.AddNewMessage(m, sender, recipients);
            //var user = _userService.Get().First();
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
