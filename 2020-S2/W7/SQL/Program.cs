using System;
using System.Data.SQLite;
using Microsoft.VisualBasic.FileIO;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Misión: Conectar con la base de datos

            // Paso 1: Crear el connection string.
            string cs = @"Data Source=.\IMDB.db";

            // Paso 2: Crear conexión con Base de Datos.
            var conn = new SQLiteConnection(cs);
            // Paso 3: Abrir la conexión con la Base de Datos
            // OJO: Por la conexión con la Base de Datos podría fallar.

            // Una Excepción puede surgir.
            try
            {
                conn.Open();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Excepción atrapada. Error: {e}");
                return;
            }

            // Si llegamos hasta acá, significa que logramos conectar con la Base de Datos
            // Ejecutar comando en la base de datos.    

            var Comando = new SQLiteCommand("SELECT * FROM Pelis", conn);
            try
            {
                var Resultado = Comando.ExecuteReader();
                Console.WriteLine(Resultado.ToString());
                Console.WriteLine($"Afectados: {Resultado.RecordsAffected} registros");
                var datos = Resultado.Read();
                var valores = Resultado.GetValues();
                foreach(var e in valores){
                    Console.WriteLine(e);
                }

                while (Resultado.Read()){
                   Console.WriteLine($"{Resultado.GetString(0)},{Resultado.GetString(1)} ");
                }
                CrearPelicula(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Upps! Algo salió terriblemente mal.");
            }

            // BorrarValor(conn);
            // InsertarValor(conn);
            Console.WriteLine("Esto viene después del try-catch");
        }


        static void CrearPelicula(SQLiteConnection conn )
        {
            SQLiteCommand cmd = conn.CreateCommand();
            Console.WriteLine("Rank: ");
            var Rank = Console.ReadLine();
            Console.WriteLine("Title: ");
            var Title = Console.ReadLine();
            Console.WriteLine("Director: ");
            var Director = Console.ReadLine();
            cmd.CommandText = $"INSERT INTO Pelis (Rank, Title, Director) VALUES('{Rank}', '{Title}', '{Director}')";
            cmd.ExecuteNonQuery();

        }
        static void BorrarValor(SQLiteConnection conn )
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Pelis Where Rank = 1";

            cmd.ExecuteNonQuery();
            Console.WriteLine("Borrado el registro");
        }
        static void InsertarValor(SQLiteConnection conn )
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Pelis (Rank, Title, Director) VALUES('1001', 'Mi Peli', 'Daniel Lozano')";

            cmd.ExecuteNonQuery();
            Console.WriteLine("Agregado el registro");
        }

    }
}
