namespace StudyPattern
{
    public class LaptopAsusBuilder : LaptopBuilder
    {
        public LaptopAsusBuilder()
        {
            Laptop = new Laptop();
        }

        public override void BuildBrand()
        {
            Laptop.Brand = "Asus";
        }

        public override void BuildScreenSize()
        {
            Laptop.ScreenSize = "15.6 inch";
        }

        public override Laptop GetLaptop()
        {
            return Laptop;
        }
    }
}