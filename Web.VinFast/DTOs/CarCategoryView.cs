using Web.VinFast.Models;

namespace Web.VinFast.DTOs
{
    public class CarCategoryView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Car>? Cars { get; set; }

    }
}
