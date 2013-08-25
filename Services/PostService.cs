using System;
using DataAccess;
using DomainModels;

namespace Services
{
    public class PostService : ServiceBase<Post>,IPostService
    {
        public void AddNewPost(Post post,User user)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
               var userRepository = unitOfWork.GetRepository<User>();
               var postRepository = unitOfWork.GetRepository<Post>();
                userRepository.Attach(user);
                post.Author = user;
                post.PostedTime = DateTime.Now;
                postRepository.Insert(post);
                unitOfWork.CommitChanges();
            }
        }

        public void AddPostComment(Comment comment, Post post, User commentator)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var postRepository = unitOfWork.GetRepository<Post>();
                var commentRepository = unitOfWork.GetRepository<Comment>();
                userRepository.Attach(commentator);
                postRepository.Attach(post);
                comment.AdditionTime = DateTime.Now;
                comment.Commentator = commentator;
                commentRepository.Insert(comment);
                unitOfWork.CommitChanges();
            }
        }

        public void Repost(Post post, User reposter)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var postRepository = unitOfWork.GetRepository<Post>();
                var repostRepository = unitOfWork.GetRepository<Repost>();
                userRepository.Attach(reposter);
                postRepository.Attach(post);
                var repost = new Repost {PostedTime = DateTime.Now, Author = reposter,OriginalPost = post};
                repostRepository.Insert(repost);
                unitOfWork.CommitChanges();
            }
        }
    }
    
}
