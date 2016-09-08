using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SportsStore.DAL;
using SportsStore.Infrastructre;
using SportsStore.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace SportsStore.Controllers
{
    public class PrepController : Controller
    {
        readonly IRepository repository = null;

        public PrepController()
        {
            repository = new Repository();
        }

        // GET: Prep
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await repository.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            await repository.SaveProductAsync(product);
            return RedirectToAction("Index");
        }


        public ActionResult Orders()
        {
            return View(repository.Orders);
        }
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await repository.DeleteOrderAsync(id);
            return RedirectToAction("Orders");
        }
        public async Task<ActionResult> SaveOrder(Order order)
        {
            await repository.SaveOrderAsync(order);
            return RedirectToAction("Orders");
        }


        public async Task<ActionResult> SignIn()
        {
            IAuthenticationManager authMgr = HttpContext.GetOwinContext().Authentication;

            StoreUserManager userMrg = Request.GetOwinContext().GetUserManager<StoreUserManager>();
            StoreUser user = await userMrg.FindAsync("Admin", "secret");

            authMgr.SignIn(await userMrg.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));

            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
    }
}