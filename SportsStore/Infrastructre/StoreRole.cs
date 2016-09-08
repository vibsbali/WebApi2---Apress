using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsStore.Infrastructre
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
