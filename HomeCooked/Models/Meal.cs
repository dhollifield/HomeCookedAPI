namespace HomeCooked.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public string MainDish { get; set; }

        public string SideDish1 { get; set; }

        public string SideDish2 { get; set; }

        public int FuelTypeId { get; set; }

        public FuelType FuelType{ get; set; }
        
    }
}
