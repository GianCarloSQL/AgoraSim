using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class Calculadora
    {
        [Key]
        public int Id { get; set; }

        public double GetPeso(double d, double v) {
            return v*d*9.87;
        }
    }
}
