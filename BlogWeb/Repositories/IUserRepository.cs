using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
