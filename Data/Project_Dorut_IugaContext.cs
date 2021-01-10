using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Data
{
    public class Project_Dorut_IugaContext : DbContext
    {
        public Project_Dorut_IugaContext (DbContextOptions<Project_Dorut_IugaContext> options)
            : base(options)
        {
        }

        public DbSet<Project_Dorut_Iuga.Models.Game> Game { get; set; }

        public DbSet<Project_Dorut_Iuga.Models.Developer> Developer { get; set; }

        public DbSet<Project_Dorut_Iuga.Models.Category> Category { get; set; }
    
    }
}
