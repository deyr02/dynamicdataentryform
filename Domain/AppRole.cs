using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppRole : IdentityRole
    {

    }

    public enum Roles
    {
        Admin, Creator
    }

    
}