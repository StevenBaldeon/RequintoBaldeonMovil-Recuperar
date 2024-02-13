using System;
//using System.ComponentModel.DataAnnotations;

namespace RequintoBaldeonMovil.Models
{
    public class Evento
    {
       
        public decimal EVE_CODIGO { get; set; }
        public string EVE_NOMBRE { get; set; }
        public string EVE_DESCRIPCION { get; set; }
        public string EVE_FECHA { get; set; }
        public string EVE_HORA { get; set; }
        public string EVE_UBICACION { get; set; }
        public string EVE_PRECIO_ENTRADA { get; set; }
        public string EVE_IMAGEN { get; set; }
        public string EVE_OBSERVACION{ get; set; }

    }
}
