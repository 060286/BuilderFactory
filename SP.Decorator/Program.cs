namespace SP.Decorator
{
    public abstract class Pizza
    {
        public abstract string GetDescription();

        public abstract double GetCost();
    }

    public class PlainPizza : Pizza
    {
        public override string GetDescription()
        {
            return "Plain Pizza";
        }

        public override double GetCost()
        {
            return 0.5;
        }
    }

    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza { get; set; }

        public PizzaDecorator(Pizza pizza)
        {
            Pizza = pizza;
        }
    }

    public class PepperoniPizzaDecorator : PizzaDecorator
    {
        public PepperoniPizzaDecorator(Pizza pizza) : base(pizza) { }
        
        public override string GetDescription()
        {
            return Pizza.GetDescription() + " with pepperoni";
        }

        public override double GetCost()
        {
            return Pizza.GetCost() + 0.5;
        }
    }

    public class MushroomPizzaDecorator : PizzaDecorator
    {
        public MushroomPizzaDecorator(Pizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return Pizza.GetDescription() + " with mushroom";
        }

        public override double GetCost()
        {
            return Pizza.GetCost() + 1.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Star Programming...");

            Pizza pizza = new PlainPizza();                        

            Console.WriteLine("Client want the pizza with pepperoni");

            pizza = new PepperoniPizzaDecorator(pizza);

            Console.WriteLine("-------------------");
            Console.WriteLine($"Result : Description > {pizza.GetDescription()}; Cost > {pizza.GetCost()}");
            Console.WriteLine("..End..");
        }
    }
}