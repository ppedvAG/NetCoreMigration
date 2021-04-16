using LiteDB;
using System;

namespace HalloLiteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var db = new LiteDatabase(@"C:\Users\rulan\Documents\litedb"))
            {
                var col = db.GetCollection<Auto>("Autos");

                //foreach (var item in col.Query().ToList())
                //{
                //    Console.WriteLine(item.Hersteller);
                //}
                col.Insert(new Auto() { Hersteller = "Baudi"});


            }

            Console.ReadLine();


        }

        internal class Auto
        {
            public string Hersteller { get; set; }
            //public string Modell { get; set; }
        }
    }
}
