﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("SportsStoreDb")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
