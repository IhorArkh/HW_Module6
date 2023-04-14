using HW_6_4_IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace HW_6_4_IdentityServer.Services
{
    public sealed class MemoryUserRepository : IUserRepository
    {
        private static readonly TimeSpan ExpiresIn = TimeSpan.FromMinutes(4);
        private readonly IMemoryCache _userMemoryCache;

        public MemoryUserRepository(IMemoryCache userMemoryCache)
        {
            _userMemoryCache = userMemoryCache;
            AddUserAsync(new DbUser
            {
                Id = Guid.NewGuid().ToString(),
                PasswordHash = "汱ĉ홠牿⭖틆㹲鯧찚�牼ӆ�ꚻ䴻",
                UserName = "Ihor",
                Type = "Admin",
                CreatedUtc = DateTime.UtcNow
            });
            AddUserAsync(new DbUser
            {
                Id = Guid.NewGuid().ToString(),
                PasswordHash = "汱ĉ홠牿⭖틆㹲鯧찚�牼ӆ�ꚻ䴻",
                UserName = "Dan",
                Type = "DefaultUser",
                CreatedUtc = DateTime.UtcNow
            });
        }

        public Task AddUserAsync(DbUser dbUser)
        {
            _userMemoryCache.Set(dbUser.UserName, dbUser);
            return Task.CompletedTask;
        }

        public Task<DbUser> GetUserByNameAsync(string userName)
        {
            return Task.FromResult(_userMemoryCache.Get<DbUser>(userName));
        }
    }
}
