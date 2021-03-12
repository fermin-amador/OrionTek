using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Models
{
    [Table("Direcciones")]
    public class Direccion
    {
        [Key]
        public int direccionId { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
        public string calle { get; set; }
        public string ciudad { get; set; }
        public string codigoPostal { get; set; }

    }
}
