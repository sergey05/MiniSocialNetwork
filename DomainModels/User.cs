using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class User
    {
        private ICollection<Subscription> _subscribers;
        private ICollection<Message> _outboxMessages;
        private ICollection<Message> _inboxMessages;
        private ICollection<Post> _myPosts;
        private ICollection<User> _myBlackList;
        private ICollection<Subscription> _mySubscriptions;
        private ICollection<User> _deniedAccessUsers;
        private ICollection<Post> _likes;

        public User()
        {
            _subscribers = new List<Subscription>();
            _mySubscriptions = new List<Subscription>();
            _outboxMessages = new List<Message>();
            _myPosts = new List<Post>();
            _myBlackList = new List<User>();
            _deniedAccessUsers = new List<User>();
            _inboxMessages = new List<Message>();
            _likes = new List<Post>();
            HasExpiredPassword = false;
            IsBlocked = false;
            HasAccess = true;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        public bool HasExpiredPassword { get; set; }
        public bool IsBlocked { get; set; }
        public bool HasAccess { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public string JobPosition { get; set; }
        public string Company { get; set; }
        public string University { get; set; }
        public string UniversityDepartment { get; set; }
        public string Major { get; set; }
        public MilitarStatus MilitarStatus { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Subscription> Subscribers
        {
            get { return _subscribers; }
            set { _subscribers = value; }
        }

        public virtual ICollection<Subscription> MySubscriptions
        {
            get { return _mySubscriptions; }
            set { _mySubscriptions = value; }
        }
        public virtual ICollection<Message> OutboxMessages
        {
            get { return _outboxMessages; }
            set { _outboxMessages = value; }
        }

        public virtual ICollection<Post> MyPosts
        {
            get { return _myPosts; }
            set { _myPosts = value; }
        }

        public virtual ICollection<User> MyBlackList
        {
            get { return _myBlackList; }
            set { _myBlackList = value; }
        }

        public virtual ICollection<User> DeniedAccessUsers
        {
            get { return _deniedAccessUsers; }
            set { _deniedAccessUsers = value; }
        }

        public virtual ICollection<Post> Likes
        {
            get { return _likes; }
            set { _likes = value; }
        }

        public virtual ICollection<Message> InboxMessages
        {
            get { return _inboxMessages; }
            set { _inboxMessages = value; }
        }
    }
}
