namespace StudyPattern
{
    public class LaptopMsiBuilder : LaptopBuilder
    {
        public LaptopMsiBuilder()
        {
            Laptop = new Laptop();
        }

        public override void BuildBrand()
        {
            Laptop.Brand = "MSI";
        }

        public override void BuildScreenSize()
        {
            Laptop.ScreenSize = "13.3";
        }

        public override Laptop GetLaptop() => Laptop;
    }
}