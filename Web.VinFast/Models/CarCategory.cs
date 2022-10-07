namespace Web.VinFast.Models
{
    public class CarCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Car>? Cars { get; set; }

    }
}
