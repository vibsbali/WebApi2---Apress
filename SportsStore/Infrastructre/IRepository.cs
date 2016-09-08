using SportsStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsStore.Infrastructre
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        Task<int> SaveProductAsync(Product product);
        Task<Product> DeleteProductAsync(int productId);


        IEnumerable<Order> Orders { get; }
        Task<int> SaveOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int orderId);
    }
}