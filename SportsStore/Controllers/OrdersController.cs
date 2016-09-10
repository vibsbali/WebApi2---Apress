using SportsStore.DAL;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IRepository repository;

        public OrdersController()
        {
            repository = (IRepository)GlobalConfiguration.Configuration
                .DependencyResolver.GetService(typeof(IRepository));
        }

        [Authorize(Roles = "Administrators")]
        public IEnumerable<Order> GetOrders()
        {
            return repository.Orders;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                IDictionary<int, Product> products = repository.Products.Where(
                    p => order.Lines.Select(ol => ol.ProductId)
                        .Any(id => id == p.Id)).ToDictionary(p => p.Id);

                order.TotalCost = order.Lines.Sum(ol => ol.Count * products[ol.ProductId].Price);
                await repository.SaveOrderAsync(order);
                return Ok();
            }

            return BadRequest(ModelState);
        }


        [Authorize(Roles = "Administrators")]
        public async Task DeleteOrder(int id)
        {
            await repository.DeleteOrderAsync(id);
        }
    }
}
