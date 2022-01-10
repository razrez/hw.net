using System.ComponentModel.DataAnnotations;
namespace DB;   

public class Monster
{
    [Key]
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int AttackModifier { get; set; } // +
    public int AttackPerRound { get; set; }
    public int Damage { get; set; }         
    public int DamageModifier { get; set; } // +
    public int Weapon { get; set; }         // +
    public int AC { get; set; }
    
    public int MinACtoAlwaysHit { get; set; }
    public int DamagePerRound { get; set; }
}