using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class AportesDetalles
    {
        [Key]
        public int ID { get; set; }
        public int TipoAporteID { get; set; }
        public int AporteID { get; set; }
        public float Valor { get; set; }


        [ForeignKey("TipoAporteID")]
        public virtual TipoAportes TiposAporte { get; set; }


        public AportesDetalles()
        {
            ID = 0;
            TipoAporteID = 0;
            Valor = 0;
            TiposAporte = null;
        }
        public AportesDetalles(int tipoId, float valor, Personas persona, TipoAportes tipo)
        {
            ID = 0;
            TipoAporteID = tipoId;
            Valor = valor;
            TiposAporte = tipo;

        }
    }
}
