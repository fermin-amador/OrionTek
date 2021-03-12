using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int genero { get; set; }
        public string telefono { get; set; }
        public ICollection<Direccion> direcciones { get; set; }
        public int empresaId { get; set; }
        public Empresa empresa { get; set; }
    }
}
