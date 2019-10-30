using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImoveisSystems.Models
{
    public class Property
    {
        public Property() { }

        public Property(string cep,string log, string bairo, string muni, int n,string comlp, Owner o) {
            Cep = cep;
            Logradouro = log;
            Bairro = bairo;
            Municipio = muni;
            Numero = n;
            Complemento = comlp;
            PropertyOwner = o;
        }

        [Key]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Owner PropertyOwner { get; set; }

        
    }
}