using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Producto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }


        public string TiendaID { get; set; }
        public Tienda Tienda { get; set; }

    }
}