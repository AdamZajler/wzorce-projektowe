using Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // Tworzymy klase która zawiera wszystkie dane jakie powinen lub MOŻE zawierać produkt.
    // Dodatkowo powinny być tu funkcje do ustawiania / pobierania danych
    public class Pizza
    {
        private String ciasto;
        private String ser;
        private String mieso;
        private String warzywa;
        private String spice;

        public String getCiasto()
        {
            return ciasto;
        }
        public void setCiasto(String ciasto)
        {
            this.ciasto = ciasto;
        }
        public String getSer()
        {
            return ser;
        }
        public void setSer(String ser)
        {
            this.ser = ser;
        }
        public String getMieso()
        {
            return mieso;
        }
        public void setMieso(String mieso)
        {
            this.mieso = mieso;
        }
        public String getWarzywa()
        {
            return warzywa;
        }
        public void setWarzywa(String warzywa)
        {
            this.warzywa = warzywa;
        }
        public String getSpices()
        {
            return spice;
        }
        public void setSpices(String spice)
        {
            this.spice = spice;
        }
    }

    // Interfejs który definiuje metody buildera

    public interface IPizzaBuilder
    {
        void AddCrust(string crust);
        void AddMeats(string meats);
        void AddCheeses(string cheeses);
        void AddVegetables(string vegetables);
        void AddSpices(string spices);
        Pizza GetPizza();
    }

    // Builder pizzy
    public class PizzaBuilder: IPizzaBuilder
    {
        private Pizza pizza = new Pizza();

        public void AddCrust(string crust)
        {
            pizza.setCiasto(crust);
        }

        public void AddMeats(string meats)
        {
            pizza.setMieso(meats);
        }

        public void AddCheeses(string cheeses)
        {
            pizza.setSer(cheeses);
        }

        public void AddVegetables(string vegetables)
        {
            pizza.setWarzywa(vegetables);
        }

        public void AddSpices(string spices)
        {
            pizza.setSpices(spices);
        }

        public Pizza GetPizza()
        {
            return pizza;
        }
    }

    // Director zbiera różne metody budowania pizzy
    public class Director
    {
        public Pizza ConstructHawaiiPizza(IPizzaBuilder builder)
        {
            builder.AddCrust("Cienkie ciasto");
            builder.AddMeats("Szynka");
            builder.AddCheeses("Ser x2");
            builder.AddVegetables("Ananas");
            builder.AddSpices("Oregano, Bazylia");

            return builder.GetPizza();
        }
    }

}

internal class Program
    {
        static void Main(string[] args)
        {
            IPizzaBuilder pizza = new PizzaBuilder();
            var director = new Director();
            Pizza hawaiianPizza = director.ConstructHawaiiPizza(pizza);

            Console.WriteLine($"Hawajska: {hawaiianPizza.getCiasto()}, {hawaiianPizza.getSer()}, {hawaiianPizza.getWarzywa()}, {hawaiianPizza.getSpices()}");

            Console.ReadKey();
        }
}
