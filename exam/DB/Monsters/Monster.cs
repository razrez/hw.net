using System.ComponentModel.DataAnnotations;
namespace DB;   

public class Monster
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int HitPoints { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int AttackModifier { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int DamageModifier { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int AttackPerRound { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Damage { get; set; }


    [Required]
    [Range(1, int.MaxValue)]
    public int AC { get; set; }
}