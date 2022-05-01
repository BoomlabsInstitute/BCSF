using System;
using System.Collections.Generic;

namespace MiTiendita.Models
{
    public class Tienda
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Balance { get; set; }

        public List<Producto> Productos { get; set; }
    }
}