﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class User
    {
        private ICollection<User> _subscribers;
        private ICollection<Message> _messages;
        private ICollection<Post> _myPosts;
        private ICollection<User> _blackList;
        private ICollection<Post> _wall;

        public User()
        {
            _subscribers = new List<User>();
            _messages = new List<Message>();
            _myPosts = new List<Post>();
            _blackList = new List<User>();
            _wall = new List<Post>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Foto { get; set; }
        public DateTime DateOfBirth { get; set; }
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

        public virtual ICollection<User> Subscribers
        {
            get { return _subscribers; }
            set { _subscribers = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public virtual ICollection<Post> MyPosts
        {
            get { return _myPosts; }
            set { _myPosts = value; }
        }

        public virtual ICollection<User> BlackList
        {
            get { return _blackList; }
            set { _blackList = value; }
        }

        public virtual ICollection<Post> Wall
        {
            get { return _wall; }
            set { _wall = value; }
        }
    }
}
