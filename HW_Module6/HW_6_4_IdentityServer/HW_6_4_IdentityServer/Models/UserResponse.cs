﻿namespace HW_6_4_IdentityServer.Models
{
    public sealed class UserResponse
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
