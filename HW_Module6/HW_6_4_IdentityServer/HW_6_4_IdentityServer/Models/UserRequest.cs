using System.ComponentModel.DataAnnotations;

namespace HW_6_4_IdentityServer.Models
{
    public sealed class UserRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
