using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "enter your name!")]
        [MaxLength(20, ErrorMessage = "20 symbols - maximum!")]
        [DisplayName("Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "enter your surname!")]
        [MaxLength(30, ErrorMessage = "30 symbols - maximum")]
        [DisplayName("Surname")]
        public string LastName { get; set; }
        
        [MaxLength(30, ErrorMessage = "30 symbols - maximum")]
        [DisplayName("Favourite Meal:")]
        public string FavouriteMeal { get; set; }
        
        [Required(ErrorMessage = "enter your age!")]
        [Range(12, 128, ErrorMessage = "excpetced range: 12 - 128 ")]
        [DisplayName("Age")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "choose your gender!")]
        [DisplayName("Gender")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}