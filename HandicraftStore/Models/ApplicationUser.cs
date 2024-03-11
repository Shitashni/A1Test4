using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using HandicraftStore.Data;

using System.ComponentModel.DataAnnotations.Schema;
namespace HandicraftStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
