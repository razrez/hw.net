using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class MyFighter : Characteristics
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}