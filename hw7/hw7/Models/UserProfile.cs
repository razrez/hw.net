using System.ComponentModel.DataAnnotations;

namespace hw7.Models
{
    public record UserProfile([Required] string? FirstName, string? LastName, Sex Sex, int Age)
    {
    }

    public enum Sex
    {
        Male,
        Female
    }
}