namespace Web.VinFast.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CarCategory? CarCategory { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
