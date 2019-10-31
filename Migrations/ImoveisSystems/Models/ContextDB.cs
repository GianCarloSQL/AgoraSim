using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImoveisSystems.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }

    }
}