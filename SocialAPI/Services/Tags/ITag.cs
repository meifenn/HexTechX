using Infra.Models;

namespace SocialAPI.Services.Tags
{
    public interface ITag
    {
        Task<List<Tag>> Get();
    }
}
