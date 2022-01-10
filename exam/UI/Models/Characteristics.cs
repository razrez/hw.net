using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Logic.Models
{
    public class Characteristics
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int HitPoints { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AttackModifier { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AttackPerRound { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Damage { get; init; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int DiceType { get; set; } 

        [Required]
        [Range(0, int.MaxValue)]
        public int DamageModifier { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ArmorClass { get; init; }

        public int MinACToAlwaysHit => AttackModifier + 1;
        public int DamagePerRound => (Damage + DamageModifier) * AttackPerRound;
    }
}