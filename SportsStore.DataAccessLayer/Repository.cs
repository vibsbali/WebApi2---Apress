using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.DataAccessLayer
{
    public class Repository : IRepository
    {
        public IEnumerable<Product> Products { get; }
        public Task<int> SaveProductsAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Orders { get; }
        public Task<int> SaveOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
