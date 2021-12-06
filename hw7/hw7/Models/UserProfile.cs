using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "УКАЖИТЕ ИМЯ ПЖ")]
        [MaxLength(20, ErrorMessage = "20 символов - максимум")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "УКАЖИТЕ ФАМИЛИЮ ПЖ")]
        [MaxLength(30, ErrorMessage = "30 символов - максимум!")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        
        [MaxLength(30, ErrorMessage = "30 символов - максимум!")]
        [DisplayName("Любимое блюдо =)")]
        public string FavouriteMeal { get; set; }
        
        [Required(ErrorMessage = "УКАЖИТЕ ВОЗРАСТ ПЖ")]
        [Range(12, 128, ErrorMessage = "Допустимый возраст: от 12 до 128 лет!")]
        [DisplayName("Возраст")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "УКАЖИТЕ ГЕНДЕР ПЖ")]
        [DisplayName("Пол")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}