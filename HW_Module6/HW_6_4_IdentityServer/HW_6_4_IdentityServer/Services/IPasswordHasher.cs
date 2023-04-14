namespace HW_6_4_IdentityServer.Services
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
    }
}
