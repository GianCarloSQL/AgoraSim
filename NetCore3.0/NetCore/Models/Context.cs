using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Models;

namespace NetCore.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options) {

        }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<NetCore.Models.Calculadora> Calculadora { get; set; }
    }
}
