using System;
using System.Collections.Generic;

public interface ICoffeeDecorator
{
    string Description { get; }
    List<string> Extras { get; }
}

public class Coffee : ICoffeeDecorator
{
    public string Description { get; set; }
    public List<string> Extras { get; set; }

    public Coffee(string description, List<string> extras)
    {
        Description = description;
        Extras = extras;
    }
}

public class MilkDecorator : ICoffeeDecorator
{
    private readonly ICoffeeDecorator _baseCoffee;

    public MilkDecorator(ICoffeeDecorator baseCoffee)
    {
        _baseCoffee = baseCoffee;
        Description = _baseCoffee.Description + ", Milk";
        Extras = new List<string>(_baseCoffee.Extras) { "milk" };
    }

    public string Description { get; }
    public List<string> Extras { get; }
}

public class SugarDecorator : ICoffeeDecorator
{
    private readonly ICoffeeDecorator _baseCoffee;

    public SugarDecorator(ICoffeeDecorator baseCoffee)
    {
        _baseCoffee = baseCoffee;
        Description = _baseCoffee.Description + ", Sugar";
        Extras = new List<string>(_baseCoffee.Extras) { "sugar" };
    }

    public string Description { get; }
    public List<string> Extras { get; }
}

public class SyrupDecorator : ICoffeeDecorator
{
    private readonly ICoffeeDecorator _baseCoffee;
    private readonly string _flavor;

    public SyrupDecorator(ICoffeeDecorator baseCoffee, string flavor)
    {
        _baseCoffee = baseCoffee;
        _flavor = flavor;
        Description = _baseCoffee.Description + ", " + _flavor + " Syrup";
        Extras = new List<string>(_baseCoffee.Extras) { _flavor };
    }

    public string Description { get; }
    public List<string> Extras { get; }
}

public class Program
{
    static void Main(string[] args)
    {
        ICoffeeDecorator baseCoffee = new Coffee("Capuchino", new List<string>());

        ICoffeeDecorator withMilk = new MilkDecorator(baseCoffee);
        Console.WriteLine(withMilk);

        ICoffeeDecorator withSugar = new SugarDecorator(withMilk);
        Console.WriteLine(withSugar);

        ICoffeeDecorator wihtSyrup = new SyrupDecorator(withSugar, "vanilla");
        Console.WriteLine(wihtSyrup);

        Console.ReadKey();
    }
}
