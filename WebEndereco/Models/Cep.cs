using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndereco.Models
{
    public class Cep
    {
        [Required]
        [MaxLength(9, ErrorMessage = "Cep tem que ser digitado no formato 70000000")]
        [MinLength(9, ErrorMessage = "Cep tem que ser digitado no formato 70000000")]
        public string Codigo { get; set; }
    }
}
