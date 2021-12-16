using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BookStore
{

    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookStoreContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["gr606_sosan"].ConnectionString);

        }
    }
}
