using System;
using System.Collections.Generic;

namespace TiendaApp.Modelos {

    public class Tienda {

        public string Nombre { get; set; }
        public bool Abierto { get; set; }

        private float Caja { get; set; }

        public List<Producto> Productos { get; set; }


        public void AgregarProducto(Producto p){
            this.Productos.Add(p);
        }

        public void BorrarProducto(int id){
            Producto p = this.Productos.Find(c => c.ID == id);
            if(p == null){
                Console.WriteLine($"El producto {id} no existe.");
            }

            this.Productos.Remove(p);
            Console.WriteLine($"El producto ha sido eliminado.");

        }

        public void MostrarProducto(int id){

            Producto p = this.Productos.Find(c => c.ID == id);

            if(p != null){
                Console.WriteLine($"\n\nID: {p.ID} \nTitulo: {p.Titulo} \nRestantes: {p.Restantes}\nPrecio: {p.Precio} \n\n");
            } else {
                Console.WriteLine($"El producto {id} no existe");
            }

        }

        public void VenderProducto(int id){
            // Las existencias del producto se van a disminuir y la caja va a aumentar
            Producto p = this.Productos.Find(c => c.ID == id);

            this.Productos.Remove(p);
            p.Restantes--;
            this.Productos.Add(p);

            this.Caja += p.Precio;
            Console.WriteLine($"En la caja hay: {this.Caja}");
        }

        public void ImprimirProductos(){
            foreach(Producto p in this.Productos){
                Console.WriteLine($"\n\nID: {p.ID} \nTitulo: {p.Titulo} \nRestantes: {p.Restantes}\nPrecio: {p.Precio} \n\n");
            }
        }

    }

}