using System;
using System.Collections.Generic;

namespace EF2.Models{

    public class Tienda {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Producto> Products { get; set; }
    }

}