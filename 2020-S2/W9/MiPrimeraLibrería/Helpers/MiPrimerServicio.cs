using System;
using MiTiendita.Models;

namespace MiTiendita.Helpers 
{
    public class MiPrimerServicio
    {
        public MiPrimerServicio()
        {
            Console.WriteLine("Hola desde MiPrimerServicio. Instancia fue creada.");
        }

        public double CalcularPrecio(Producto producto, int cantidad)
        {
            return producto.Precio * cantidad;
        }
    }
}