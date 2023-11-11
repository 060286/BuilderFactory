// See https://aka.ms/new-console-template for more information

public abstract class Component
{
    public abstract string ToString();
}

public class File : Component
{
    private string _Name;

    public File(string name)
    {
        _Name = name;
    }

    public override string ToString()
    {
        return _Name;
    }
}

public class Directory : Component
{
    private List<Component> _children = new List<Component>();

    private string Name { get; set; }

    public Directory(string name)
    {
        Name = name;
    }

    public void Add(Component component)
    {
        _children.Add(component);
    }

    public void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override string ToString()
    {
        string result = Name + "{ ";

        foreach (Component component in _children)
        {
            result += " " + component.ToString();
        }

        result += " }";

        return result;
    }
}

static class Program
{
    static void Main(string[] args)
    {
        Directory rootDirectory = new Directory("root");

        rootDirectory.Add(new File("file1.txt"));

        rootDirectory.Add(new Directory("directory1"));

        Console.WriteLine(rootDirectory.ToString());
    }
}