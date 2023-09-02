namespace Amrita.IdentityManager.Domain;

using Microsoft.AspNetCore.Identity;

public class AmritaUser: IdentityUser
{
    public string FullName { get; set; } = null!;
    public string? ProfilePictureUrl { get; set; } 
    public bool IsInternal { get; set; }
}