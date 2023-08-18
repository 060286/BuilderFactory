// See https://aka.ms/new-console-template for more information
using StudyPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var builder = new LaptopAsusBuilder();
        builder.BuildBrand();
        builder.BuildScreenSize();
        Laptop laptop = builder.GetLaptop();

        Console.WriteLine($"Result: {laptop.Brand} - {laptop.ScreenSize}");

        var builderMsi = new LaptopMsiBuilder();
        builderMsi.BuildBrand();
        builderMsi.BuildScreenSize();
        Laptop laptopMsi = builderMsi.GetLaptop();

        Console.WriteLine($"Result: {laptopMsi.Brand} - {laptopMsi.ScreenSize}");

        Console.ReadKey();
    }
}