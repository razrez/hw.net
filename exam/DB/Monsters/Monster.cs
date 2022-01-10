using System.ComponentModel.DataAnnotations;
namespace DB;   

public class Monster
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1, 100)]
    public int HitPoints { get; set; }

    [Required]
    [Range(1, 100)]
    public int AttackModifier { get; set; }
    
    [Required]
    [Range(1, 100)]
    public int DamageModifier { get; set; }

    [Required]
    [Range(1, 100)]
    public int AttackPerRound { get; set; }

    [Required]
    [Range(1, 100)]
    public int Damage { get; set; }


    [Required]
    [Range(1, 100)]
    public int AC { get; set; }
}