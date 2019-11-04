using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class Bicicleta
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
