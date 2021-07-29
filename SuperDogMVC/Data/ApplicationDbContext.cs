using Microsoft.EntityFrameworkCore;
using SuperDogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDogMVC.Data
{
    // this is our database connection
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SDEvent> Events { get; set; }
    }
}
