// using System;
// using System.IO;
// using System.Data.SQLite;
// using Microsoft.VisualBasic.FileIO;

// namespace W8SQL
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // int contador = 0;
//             // string linea;

//             // // Read the file and display it line by line.  
//             // System.IO.StreamReader file = new System.IO.StreamReader(@".\IMDB-Movie-Data.csv");
//             // while ((linea = file.ReadLine()) != null)
//             // {
//             //     System.Console.WriteLine(linea);
//             //     contador++;
//             // }

//             // file.Close();
//             // System.Console.WriteLine("Habían {0} líneas.", contador);
//             // // Suspend the screen.  
//             // System.Console.ReadLine();

//             string cs = @"Data Source=.\Movies.db";
//             string stm = "SELECT Title FROM Movies";

//             using var con = new SQLiteConnection(cs);
//             con.Open();
//             using var cmd = new SQLiteCommand(stm, con);

//             string version = cmd.ExecuteReader().ToString();
//             Console.WriteLine($"SQLite version: {version}");
//             // using (TextFieldParser parser = new TextFieldParser(@".\IMDB-Movie-Data.csv"))
//             // {
//             //     parser.TextFieldType = FieldType.Delimited;
//             //     parser.SetDelimiters(",");
//             //     while (!parser.EndOfData)
//             //     {
//             //         //Processing row
//             //         string[] fields = parser.ReadFields();

//             //         foreach (string field in fields)
//             //         {
//             //             //TODO: Process field
//             //             System.Console.WriteLine(field);
//             //         }
//             //     }
//             // }
//         }
//     }
// }


using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace W8SQL
{
    class Program
    {

        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn; // Crear var de la conn
            sqlite_conn = CreateConnection();
            ReadData(sqlite_conn);
        }














        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=.\Movies.db;");
           // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
            string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();

        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Shows (Title, Rank, Genre ) VALUES('Test Text ', 1, 'Comedy'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Shows (Title, Rank) VALUES('Test1 Text1 ', 2); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Shows (Title, Rank) VALUES('Test2 Text2 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Shows (Title, Rank) VALUES('Test3 Text3 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        static void ReadData(SQLiteConnection conn)
        {

            Console.WriteLine("Qué quieres buscar?");
            string respuesta = Console.ReadLine();
            string Password = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            String.Trim(respuesta, "'")

            sqlite_cmd.CommandText = $"SELECT ID FROM Users WHERE email={} AND Password={Password};";
            // "SELECT ID FROM Users WHERE email=dlozanonavas@outlook.com; -- AND Password={Password};"
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}