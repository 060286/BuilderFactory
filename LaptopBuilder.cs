namespace StudyPattern
{
    public abstract class LaptopBuilder
    {
        public abstract void BuildBrand();

        public abstract void BuildScreenSize();

        public abstract Laptop GetLaptop();

        protected Laptop? Laptop { get; set; }
    }
}