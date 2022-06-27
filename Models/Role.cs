using Microsoft.AspNetCore.Identity;
using System;

namespace VolunTEENProject.Models
{
    public class Role : IdentityRole
    {
        public string RoleDescription { get; set; }
        public bool IsPartnerRole { get; set; }
    }
}
