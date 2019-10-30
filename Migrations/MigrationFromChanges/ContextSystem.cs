using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationFromChanges
{
    public class ContextSystem:DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
