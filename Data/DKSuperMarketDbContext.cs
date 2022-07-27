
using DKMart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Data
{
    public class DKSuperMarketDbContext : DbContext
    {

        public DKSuperMarketDbContext(DbContextOptions<DKSuperMarketDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Category { get; set; }

        public DbSet<Products> Products { get; set; }

    }
}