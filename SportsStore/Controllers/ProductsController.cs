using SportsStore.DAL;
using SportsStore.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductsController : ApiController
    {
        public IRepository Repository { get; set; }

        public ProductsController()
        {
            Repository = new Repository();
        }

        public IHttpActionResult GetProducts()
        {
            return Ok(Repository.Products);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = Repository.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest("No Product Found");
            }

            return Ok(product);
        }

        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveProductAsync(product);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);

        }
    }
}
