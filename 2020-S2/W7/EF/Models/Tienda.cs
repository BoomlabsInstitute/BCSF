using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Tienda 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Nombre { get; set; }
        public DateTime Inauguración { get; set; }

        public double BalanceCaja { get; set; }

        public List<Producto> Productos { get; set; }
    }

}