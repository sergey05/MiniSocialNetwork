using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class User
    {
        private ICollection<Subscriber> _subscribers;
        private ICollection<Message> _outboxMessages;
        private ICollection<Message> _inboxMessages;
        private ICollection<Post> _myPosts;
        private ICollection<RePost> _myRePosts;
        private ICollection<BlackListUser> _blackList;

        public User()
        {
            _subscribers = new List<Subscriber>();
            _outboxMessages = new List<Message>();
            _myPosts = new List<Post>();
            _blackList = new List<BlackListUser>();
            _myRePosts = new List<RePost>();
            _inboxMessages = new List<Message>();
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

        public virtual ICollection<Subscriber> Subscribers
        {
            get { return _subscribers; }
            set { _subscribers = value; }
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

        public virtual ICollection<BlackListUser> BlackList
        {
            get { return _blackList; }
            set { _blackList = value; }
        }


        public virtual ICollection<RePost> MyRePosts
        {
            get { return _myRePosts; }
            set { _myRePosts = value; }
        }

        public virtual ICollection<Message> InboxMessages
        {
            get { return _inboxMessages; }
            set { _inboxMessages = value; }
        }
    }
}
