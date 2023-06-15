namespace _153504_KLIMKOVICH_Lab9.Domain.Entities
{
    public class Computer
    {
        public string? name { get; set; }

        public Winchester? winchester { get; set; }

        public Computer(string? name, Winchester? winchester)
        {
            this.name = name;
            this.winchester = winchester;
        }
    }
}
