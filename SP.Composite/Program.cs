public abstract class Component
{
    public Component()
    {
        
    }

    public abstract string Operation();

    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsComposite()
    {
        return true;
    }
}

/// <summary>
/// The leaf class represents the end object of composition.
/// </summary>
public class Leaf : Component
{
    public override string Operation()
    {
        return "Leaf - The end of object";
    }

    public override bool IsComposite()
    {
        return false;
    }
}

public class Composite : Component
{
    protected List<Component> _children = new List<Component>();

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override string Operation()
    {
        int i = 0;
        string result = "Branch";

        foreach (var component in _children)
        {
            result += component.Operation();
            if (i != _children.Count - 1)
            {
                result += "+";
            }

            i++;
        }

        return result + ")";
    }
}

public class Client
{
    public void ClientCode(Component leaf)
    {
        Console.WriteLine($"Result: {leaf.Operation()}\n");
    }

    public void ClientCode2(Component component1, Component component2)
    {
        if (component1.IsComposite())
        {
            component1.Add(component2);
        }
        
        Console.WriteLine($"Result: {component1.Operation()}");
    }
}

static class Program
{
    static void Main(string[] args)
    {
        // Leaf container.
        Client client = new Client();
    
        Leaf leaf = new Leaf();
        Console.WriteLine("I get a simple component");
        client.ClientCode(leaf);
        
        // Complex container.
        Composite tree = new Composite();
        Composite branch1 = new Composite();

        branch1.Add(new Leaf());
        branch1.Add(new Leaf());

        Composite branch2 = new Composite();
        branch2.Add(new Leaf());

        tree.Add(branch1);
        tree.Add(branch2);
        Console.WriteLine("Now I have composite tree");
        client.ClientCode(tree);
        
        client.ClientCode2(tree, leaf);
    }
}