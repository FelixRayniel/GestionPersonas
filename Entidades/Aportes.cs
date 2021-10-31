using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class Aportes
    {
        //AporteId,Fecha,PersonaId,Concepto, Monto
        [Key]
        public int AporteID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaID { get; set; }
        public string Concepto { get; set; }
        public float Monto { get; set; }

        [ForeignKey("PersonaID")]
        public virtual Personas Persona { get; set; }

        [ForeignKey("AporteID")]
        public virtual List<AportesDetalles> DetalleAporte { get; set; } = new List<AportesDetalles>();
    }
}
