#region Additional Namespaces
using Security;
using Microsoft.AspNetCore.Identity;
#endregion


namespace webapp.Data
{
    public class ApplicationUser : IdentityUser, IIdentifyEmployee
    {
        public int? EmployeeId { get; set; }
    }
}
