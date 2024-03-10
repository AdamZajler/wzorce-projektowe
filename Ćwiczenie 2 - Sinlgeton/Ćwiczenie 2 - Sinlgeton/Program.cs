using System;
using System.Collections.Generic;

namespace Ćwiczenie_2___Sinlgeton
{
    class Program
    {
        public class ZadanieDrukowania
        {
            private readonly string _zawartosc;

            public ZadanieDrukowania(string zawartosc)
            {
                _zawartosc = zawartosc;
            }

            public string PobierzZawartosc()
            {
                return _zawartosc;
            }
        }

        public sealed class SingletonBuforWydruku
        {
            private static List<ZadanieDrukowania> ListaZadanDrukowania = new List<ZadanieDrukowania>();

            private SingletonBuforWydruku() { }

            private static SingletonBuforWydruku Instance = null;

            public static SingletonBuforWydruku GetInstance()
            {

                if (Instance == null)
                {
                    Instance = new SingletonBuforWydruku();
                }

                return Instance;
            }

            public void addTask(ZadanieDrukowania zadanie)
            {
                ListaZadanDrukowania.Add(zadanie);
            }

            public void printTasks()
            {
                if (ListaZadanDrukowania.Count == 0)
                {
                    Console.WriteLine("Brak zadań do wydrukowania");
                    return;
                }

                Console.WriteLine("Lista zadań do wydrukowania:");
                foreach (var zadanie in ListaZadanDrukowania)
                {
                    Console.WriteLine($"\t{zadanie.PobierzZawartosc()}");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ćwiczenie 2 - Sinlgeton\n\n");

            SingletonBuforWydruku bufor = SingletonBuforWydruku.GetInstance();

            bufor.addTask(new ZadanieDrukowania("Zadanie A"));
            bufor.addTask(new ZadanieDrukowania("Zadanie B"));

            bufor.printTasks();
        }
    }
}
