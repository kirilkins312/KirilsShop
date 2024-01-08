using KirilsShop.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace KirilsShop.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    
    }
}
