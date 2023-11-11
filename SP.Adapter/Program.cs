using System;

public class Program
{
    public static void Main(string[] args)
    {
        ILegacySystem legacy = new LegacySystem();

        INewSystem newSystem = new LegacySystemAdapter(legacy);

        Customer customer = newSystem.GetCustomer(123);
        
        Console.WriteLine($"Customer id: {customer.Id} and Customer Name: {customer.Name}");

        Console.ReadLine();
    }
}


public interface ILegacySystem
{
    string GetCustomData(int customerId);
}

public interface INewSystem
{
    Customer GetCustomer(int customerId);
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

/// <summary>
/// Legacy class.
/// </summary>
public class LegacySystem : ILegacySystem
{
    public string GetCustomData(int customerId)
    {
        return "Tam Van Le From Viet Nam";
    }
}

/// <summary>
/// Adapter class
/// </summary>
public class LegacySystemAdapter : INewSystem
{
    private readonly ILegacySystem _legacy;

    public LegacySystemAdapter(ILegacySystem legacy)
    {
        _legacy = legacy;
    }
    
    public Customer GetCustomer(int customerId)
    {
        string customerName = _legacy.GetCustomData(customerId);

        Customer customer = new Customer();

        customer.Id = customerId;
        customer.Name = customerName;

        return customer;
    }
}