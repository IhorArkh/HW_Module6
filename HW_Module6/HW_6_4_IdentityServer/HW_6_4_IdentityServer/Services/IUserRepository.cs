using HW_6_4_IdentityServer.Models;

namespace HW_6_4_IdentityServer.Services
{
    public interface IUserRepository
    {
        public Task AddUserAsync(DbUser dbUser);

        public Task<DbUser> GetUserByNameAsync(string userName);
    }
}
