using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Logic.Models
{
    public class Monster : Characteristics
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}