namespace SP.Flyweight
{
    public class TreeType
    {
        public string Name { get; set; }
        public string Texture { get; set; }
        public string Color { get; set; }

        public TreeType(string name, string texture, string color)
        {
            Name = name;
            Texture = texture;
            Color = color;
        }
    }

    public class Tree
    {
        private TreeType type;
        private int age;
        private int health;
        private string position;

        public Tree(TreeType type, int age, int health, string position)
        {
            this.type = type;
            this.age = age;
            this.health = health;
            this.position = position;
        }

        public override string ToString()
        {
            return $"Tree: {type.Name} ({age} years old, {health} health) | Position: {position}";
        }
    }

    public class TreeFactory
    {
        private Dictionary<string, TreeType> treeTypes = new Dictionary<string, TreeType>();

        public TreeType GetTreeType(string name, string texture, string color)
        {
            if(!treeTypes.ContainsKey(name))
            {
                TreeType newType = new TreeType(name, texture, color);
                treeTypes[name] = newType;

                return newType;
            }    

            return treeTypes[name];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement Flyweight Design Pattern");

            TreeFactory treeFactory = new TreeFactory();
             
            TreeType oakTreeType = treeFactory.GetTreeType("Oak", "rough bark", "green");
            TreeType birchTreeType = treeFactory.GetTreeType("Birch", "smooth bark", "white");

            Tree oakTree1 = new Tree(oakTreeType, 50, 100, "Position 1");
            Tree oakTree2 = new Tree(oakTreeType, 30, 80, "Position 2");
            Tree birchTree1 = new Tree(birchTreeType, 20, 90, "Position 3");

            Console.WriteLine(oakTree1);
            Console.WriteLine(oakTree2);
            Console.WriteLine(birchTree1);

            Console.WriteLine("Completed.");
        }
    }
}