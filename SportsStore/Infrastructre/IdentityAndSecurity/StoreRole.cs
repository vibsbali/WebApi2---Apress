using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsStore.Infrastructre.IdentityAndSecurity
{
    public class StoreRole : IdentityRole
    {
        public StoreRole() : base()
        {
            
        }

        public StoreRole(string name) : base (name)
        {
            
        }
    }
}
