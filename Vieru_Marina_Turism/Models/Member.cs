using System.ComponentModel.DataAnnotations;

namespace Vieru_Marina_Turism.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        
        public ICollection<Favourite>? Favourites { get; set; }
    }
}
