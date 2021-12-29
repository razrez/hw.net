using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hw9.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "example:\n(2+3) / 12 * 7 + 8 * 9")]
        [DisplayName("fill your expression:")]
        public string Expr { get; set; }
    }
}