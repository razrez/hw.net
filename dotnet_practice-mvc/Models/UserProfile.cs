using System.ComponentModel.DataAnnotations;

namespace dotnet_practice10_26.Models
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