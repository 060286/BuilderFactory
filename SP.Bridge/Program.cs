using System;

public class Program
{
    public static void Main(string[] args)
    {
    }
}

/// <summary>
/// Abstract Layer.
/// </summary>
public interface IDevice
{
    void TurnOn();

    void TurnOff();
}

/// <summary>
/// Implementation class
/// </summary>
public class RemoteControlDevice : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Turning on the device");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turning off the device");
    }
}

/// <summary>
/// The bridge class
/// </summary>
public abstract class DeviceBridge : IDevice
{
    protected IDevice _device;

    public DeviceBridge(IDevice device)
    {
        _device = device;
    }
    
    public virtual void TurnOn()
    {
        _device.TurnOn();
    }

    public virtual void TurnOff()
    {
        _device.TurnOff();
    }
}

public class TvDeviceBridge : DeviceBridge
{
    public TvDeviceBridge(IDevice device) : base(device)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine("Turning on the TV.");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Turning off the TV.");
    }
}
