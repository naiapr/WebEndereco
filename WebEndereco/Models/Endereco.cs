using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndereco.Models
{
   
        [Table("Endereco")]
        public class Endereco
        {
            [Key]
        public int EnderecoID { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        
      
    }
    
}
