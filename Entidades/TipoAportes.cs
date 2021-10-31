using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class TipoAportes
    {
        [Key]
        public int TipoAporteID { get; set; }
        public string Descripcion { get; set; }
        public float Meta { get; set; }
        public float Logrado { get; set; }
    }
}
