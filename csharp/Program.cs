using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Perrito Perrito1 = new Perrito();
            Perrito1.Nombre = "Lucas";
            Perrito1.Edad = 5;
            Perrito1.Patas = 4;
            Perrito1.Ojos = 2;
            Perrito1.Color = "Dorado";
            Perrito1.Raza = "Golder Retriever";


            Perrito Perrito2 = new Perrito();
            Perrito2.Nombre = "Manny";
            Perrito2.Edad = 7;
            Perrito2.Color = "Blanco";
            Perrito2.Ojos = 2;
            Perrito2.Patas = 4;
            Perrito2.Raza = "Samoyedo";

            Perrito2.Ladrar();
            Perrito1.Dormir();

            Perrito2.Dormir();
            Perrito1.Excavar();

            Perrito2.Excavar();
            Perrito1.Ladrar();


            Console.WriteLine($"Manny tiene: {Perrito2.Edad} Años." );
            Console.WriteLine($"Lucas tiene: {Perrito1.Edad} Años." );


            Perrera perrera = new Perrera();

            perrera.Perros.Add(Perrito1);
            perrera.Perros.Add(Perrito2);

            perrera.BanarPerritos();

        }
    }


    class Cheque {
        public int ID { get; set; }
        public string Bank { get; set; }
    }

    class Producto {
        public decimal precio { get; set; }
        public string Title { get; set; }

    }

    class Perrera {

        public List<Perrito> Perros = new List<Perrito>();

        public void BanarPerritos(){

            foreach(var perrito in Perros){

                Console.WriteLine($"**Bañando** {perrito.Nombre}");
            }
        }
    }

    class Perrito {

        public int Patas { get; set; }

        public int Ojos { get; set; }

        public string Nombre { get; set; }

        public string Color { get; set; }
        public string Raza { get; set; }

        public int Edad { get; set; }     

        public void Ladrar(){
            Console.WriteLine(this.Nombre + ": Wuaufff!");
        }

        public void Excavar(){
            Console.WriteLine(this.Nombre + ": **Excavando**");
        }

        public void Dormir()
        {
            Console.WriteLine(this.Nombre + ": **Durmiendo**");
        }

    }

}
