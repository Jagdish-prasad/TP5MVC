using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP5MVC.Models
{
    public class ApplicationDbContext:DbContext
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        { }
        public DbSet<Employee> Employee{ get; set; }
    }
}
