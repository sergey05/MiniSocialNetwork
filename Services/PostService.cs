using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class PostService : ServiceBase<Post>,IPostService
    {
        public void AddNewPost(Post post,User user)
        {
            using (var unitOfWork = new UnitOfWork())
            {
               var userRepository = unitOfWork.GetRepository<User>();
               var postRepository = unitOfWork.GetRepository<Post>();
                userRepository.Attach(user);
                post.Author = user;
                post.PostedTime = DateTime.Now;
                postRepository.Insert(post);
            }
        }

        public void AddPostComment(Comment comment, Post post, User commentator)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var postRepository = unitOfWork.GetRepository<Post>();
                var commentRepository = unitOfWork.GetRepository<Comment>();
                userRepository.Attach(commentator);
                postRepository.Attach(post);
                comment.Commentator = commentator;
                commentRepository.Insert(comment);
            }
        }
    }
    
}
