namespace SP.Facade
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
    }

    public class ProductManager
    {
        public List<Product> GetProducts()
        {
            return new List<Product>();
        }
    }

    public class OrderProcessor
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Process Order");
        }
    }

    public class PaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Process Payment");
        }
    }

    public class ShoppingFacade
    {
        private ProductManager productManager;
        private OrderProcessor orderProcessor;
        private PaymentProcessor paymentProcessor;

        public ShoppingFacade()
        {
            productManager = new ProductManager();
            orderProcessor = new OrderProcessor();
            paymentProcessor = new PaymentProcessor();
        }

        public List<Product> GetProducts()
        {
            return productManager.GetProducts();
        }

        public void PlaceOrder(string customerName, string shippingAddress, List<OrderItem> orderItems)
        {
            Order order = new Order();
            order.CustomerName = customerName;
            order.ShippingAddress = shippingAddress;
            order.Items = orderItems;

            orderProcessor.CreateOrder(order);
            paymentProcessor.ProcessPayment(order);
        }
    }

    /// <summary>
    /// Scenario: An online shopping system with various subsystems for product management, order processing, and payment processing.
    ///Problem: The system's complexity makes it difficult for users to interact with it directly.
    ///Solution: Implement a Facade class to provide a simplified interface for managing products, placing orders, and processing payments.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement Facade Design Pattern");

            ShoppingFacade shoppingFacade = new ShoppingFacade();

            List<Product> products = new List<Product>
            {
                new Product { Name = "Bike", Description = "Bike", Price = 10 },
                new Product { Name = "Car", Description = "Car", Price = 20 },
                new Product { Name = "Plane", Description = "Plane", Price = 100 }
            };

            List<OrderItem> ordersItem = new List<OrderItem>
            {
                new OrderItem { Product = products[0], Quantity = 10 },
                new OrderItem { Product = products[1], Quantity = 20 },
                new OrderItem { Product = products[2], Quantity = 1 }
            };

            shoppingFacade.PlaceOrder("Tam Le", "123 Main Street", ordersItem);

            Console.WriteLine("Completed Shipping");
        }
    }
}