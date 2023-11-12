namespace SP.Proxy
{
    internal class Program
    {
        public class Product
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public interface IProductInformationProvider
        {
            Product GetProduct(int id);
        }

        public class ProductInformationProvider : IProductInformationProvider
        {
            public Product GetProduct(int id)
            {
                return new Product { Id = id, Name = "Product name" };
            }
        }

        public class ProductInformationProxy : IProductInformationProvider
        {
            private IProductInformationProvider _provider;
            private Dictionary<int, Product> _productCache;

            public ProductInformationProxy(IProductInformationProvider provider)
            {
                _provider = provider;
                _productCache = new Dictionary<int, Product>();
            }

            public Product GetProduct(int id)
            {
                if (_productCache.ContainsKey(id))
                {
                    return _productCache[id];
                }

                Product product = _provider.GetProduct(id);
                _productCache.Add(id, product);

                return product;
            }
        }

        /// <summary>
        /// ref : https://refactoring.guru/design-patterns/proxy
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Implement Proxy");


            IProductInformationProvider productInformationProvider = new ProductInformationProxy(new ProductInformationProvider());

            Product product1 = productInformationProvider.GetProduct(1);
            Product product2 = productInformationProvider.GetProduct(2);

            Console.WriteLine(product1.Name + " " + product1.Id);
            Console.WriteLine(product2.Name + " " + product2.Id);
        }
    }
}