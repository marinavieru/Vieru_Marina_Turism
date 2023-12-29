using System.ComponentModel.DataAnnotations;

namespace Vieru_Marina_Turism.Models
{
    public class Flight
    {
        public int ID { get; set; }

        [Display(Name = "Airline Name")]
        public string AirlineName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }

        public ICollection<Holiday>? Holidays { get; set; }
    }
}
