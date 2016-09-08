using System.Threading.Tasks;
using System.Web.Mvc;
using SportsStore.DAL;
using SportsStore.Models;

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

        public async Task<ActionResult> DeleteProduct(int id)
        {
            await repository.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

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

    }
}