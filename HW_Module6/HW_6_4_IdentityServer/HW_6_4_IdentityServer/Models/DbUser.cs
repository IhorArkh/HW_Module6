namespace HW_6_4_IdentityServer.Models
{
    public sealed class DbUser
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
