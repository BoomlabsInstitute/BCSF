using System;
using TiendaApp.Modelos;
using System.Collections.Generic;

namespace TiendaApp
{
    class Program
    {

        static void ImprimirMenu(){
            Console.WriteLine("1. Agregar Producto.");
            Console.WriteLine("2. Borrar Producto.");
            Console.WriteLine("3. Mostrar Producto.");
            Console.WriteLine("4. Vender Producto.");
            Console.WriteLine("5. Listar Producto.");
            Console.WriteLine("6. Salir.");
        }

        static int Main(string[] args)
        {
            // Crear una aplicación que reciba el inventario de la tienda y me permita manejar las ventas.

            // Crear Tienda
            Tienda MiTienda = new Tienda();

            MiTienda.Nombre = "Mi tiendita";
            MiTienda.Abierto = true;
            MiTienda.Productos = new List<Producto>();

            while(true){


                ImprimirMenu();

                string Respuesta = Console.ReadLine();

                // Switch, Case
                
                switch(Respuesta){
                    case "1":
                        // Agregar un producto
                        Producto p = new Producto();
                        Console.Write("ID: ");
                        p.ID = Int32.Parse(Console.ReadLine());
                        Console.Write("Titulo: ");
                        p.Titulo = Console.ReadLine();
                        Console.Write("Cantidad Restante: ");
                        p.Restantes = Int32.Parse(Console.ReadLine());
                        Console.Write("Precio: ");
                        p.Precio = float.Parse( Console.ReadLine());

                        MiTienda.AgregarProducto(p);
                        break;
                    case "2":
                        // Borrar Producto
                        Console.Write("Digite el ID del producto a borrar:");
                        MiTienda.BorrarProducto(Int32.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        // Mostrar Producto
                        Console.Write("Digita el ID del producto a mostrar: ");

                        MiTienda.MostrarProducto(Int32.Parse(Console.ReadLine()));
                        break;
                    case "4":
                        // Vender Producto
                        Console.Write("Digita el ID del producto a vender: ");
                        MiTienda.VenderProducto(Int32.Parse(Console.ReadLine()));
                        break;
                    case "5":
                        MiTienda.ImprimirProductos();
                        break;
                    case "6":
                        // Salir
                        return 0;
                    default:
                        //Imprimir el menú de nuevo.
                        ImprimirMenu();
                        break;

                }


            }


            return 0;

        }
    }
}
