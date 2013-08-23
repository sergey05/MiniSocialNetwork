using DomainModels;

namespace Services
{
    public interface IPostService:IServiceBase<Post>
    {
        void AddNewPost(Post post, User user);
        void AddPostComment(Comment comment, Post post, User commentator);
        void Repost(Post post, User reposter);
    }
}
