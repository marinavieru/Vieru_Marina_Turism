using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Vieru_Marina_Turism.Models
{
    public class Holiday
    {
        public int ID { get; set; }
        public string Destinations { get; set; }

        [Display(Name = "Check-in")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-in")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int Guests { get; set; }
        public int? FlightID { get; set; }
        public Flight? Flight { get; set; }
        public int? FavouriteID { get; set; }
        public Favourite? Favourite { get; set; }
            }
}
