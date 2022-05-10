#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MELISSA.Models;

namespace MELISSA.Data
{
    public class MELISSAContext : DbContext
    {
        public MELISSAContext (DbContextOptions<MELISSAContext> options)
            : base(options)
        {
        }

        public DbSet<MELISSA.Models.Mel> Mel { get; set; }
    }
}
