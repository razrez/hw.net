using System.ComponentModel.DataAnnotations;

namespace hw9.Models
{
    public class Cache
    {
        [Key]
        public string Expression { get; set; }
        public string Value { get; set; }
    }
}