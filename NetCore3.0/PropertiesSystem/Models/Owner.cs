using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesSystem.Models
{
    public class Owner:AbstractModel
    {
        public string Nome { get; set; } 
        [EmailAddress]
        public string Email { get; set; }
    }
}
