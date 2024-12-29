namespace SocialAPI.Services.Auth
{
    public interface IAuthentication
    {
        Task<string> Authenticate(string? userName = null, string? password = null);
    }
}
