namespace _153504_KLIMKOVICH_Lab9.Domain.Entities
{
    public class Winchester
    {
        public string? name { get; set; }

        public int? price { get; set; }

        public Winchester(string? name, int? price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
