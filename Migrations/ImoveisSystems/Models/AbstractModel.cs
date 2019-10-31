using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImoveisSystems.Models
{
    public class AbstractModel
    {
        public bool Ativo { get; set; } = true;
        public int UsuarioCriacao { get; set; } = 0;
        public int UsuarioAlteracao { get; set; } = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

    }
}