namespace SocialAPI.Services.Likes
{
    public interface ILike
    {
        Task<string> ProcessLike(int userId = 0, int postId = 0);
    }
}
