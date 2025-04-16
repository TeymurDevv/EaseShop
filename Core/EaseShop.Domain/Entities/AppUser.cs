using Microsoft.AspNetCore.Identity;

namespace EaseShop.Domain.Entities;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    
    
}