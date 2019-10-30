using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImoveisSystems.Models
{
    public class Owner
    {
        public Owner() { }
        public Owner(string Nome,DateTime date,string email) {
            Name = Nome;
            Birth_Date = date;
            Email = email;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Email { get; set; }
    }
}