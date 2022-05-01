using System;
using System.ComponentModel.DataAnnotations;

namespace MiTiendita.Models
{
    public class Producto
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        public int Cantidad { get; set; }
        public double Precio { get; set; }


        [Required]
        public string Imagen { get; set; }


        public string TiendaID { get; set; }
        public Tienda Tienda { get; set; }

    }
}