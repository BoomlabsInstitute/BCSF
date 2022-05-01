using System;

namespace MiTiendita.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }


        public string TiendaID { get; set; }
        public Tienda Tienda { get; set; }

    }
}