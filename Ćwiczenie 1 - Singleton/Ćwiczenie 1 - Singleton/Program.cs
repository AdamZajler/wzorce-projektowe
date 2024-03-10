using System;
using System.Collections.Generic;

namespace Ćwiczenie_1___Singleton
{
    class Program
    {
        public sealed class Singleton
        {
            private static List<string> Messages = new List<string>();

            private Singleton() { }

            private static Singleton Instance = null;

            public static Singleton GetInstance()
            {
 
                if (Instance == null)
                {
                    Instance = new Singleton();
                }

                return Instance;
            }

            public void addMessage(string message)
            {
                Messages.Add(message);
            }

            public void printMessages()
            {
                if(Messages.Count == 0)
                {
                    Console.WriteLine("Brak komunikatów");
                    return;
                }

                Console.WriteLine("Lista komunikatów: \n");

                for (var i = 0; i < Messages.Count; i++)
                {
                    Console.WriteLine("\t{0}: {1}", i+1, Messages[i]);
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ćwiczenie 1 - Singleton\n\n");

            Singleton s1 = Singleton.GetInstance();
            s1.addMessage("Komunikat A");
            s1.addMessage("Komunikat B");

            s1.printMessages();
        }
    }
}
