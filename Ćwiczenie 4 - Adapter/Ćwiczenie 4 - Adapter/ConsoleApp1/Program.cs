using System;

namespace ConsoleApp1
{
    // Interfejs ITarget mówi nam o docelowej metodzie którą będziemy 'tłumaczyć' (czytaj. jest to
    // niekompatybilny interfejs)
    interface ITarget
    {
        void GetArea();
    }

    // Adaptee === klasa którą będzie tłumaczona. Może to być np. system który musimy zaadaptować do naszego.
    class SquareAdaptee
    {
        // Ten adaptee posiada prosta metodę która oblicza pole kwadratu
        public void GetArea(int side)
        {
            Console.WriteLine("Pole kwadratu wynosi: {0}", side * side);
        }
    }

    // Adapter === to nasz system.
    class SquareAdapter : ITarget
    {
        // Na potrzeby tłumaczenia adaptee tworzymy zmienną która ma typ klasy adaptee
        private SquareAdaptee adaptee;

        // Przy inicjacji naszego systemu wymagamy aby została przekazana zmienna z klasą adaptee
        public SquareAdapter(SquareAdaptee adaptee)
        {
            // Przypisujemy tą zmienną
            this.adaptee = adaptee;
        }

        // Tworzymy własną metodę GetArea w naszym systemie, która wywołuje bliźniaczą metodę
        // GetaArea w klasie adaptee
        public void GetArea()
        {
            adaptee.GetArea(2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy klasę adaptee
            SquareAdaptee adaptee = new SquareAdaptee();
            // Tworzymy klasę adaptera i przekazujemy jej adaptee
            SquareAdapter adapter = new SquareAdapter(adaptee);

            // Wywołuemy GetArea w adapterze która później wywołuje GetArea w adaptee
            adapter.GetArea();
        }
    }
}
