using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int empresaId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string telefono { get; set; }

        public ICollection<Cliente> clientes { get; set; }

    }
}
