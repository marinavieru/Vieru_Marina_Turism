using System.ComponentModel.DataAnnotations;

namespace Vieru_Marina_Turism.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? HolidayID { get; set; }
        public Holiday? Holiday { get; set; }
       
    }
}
