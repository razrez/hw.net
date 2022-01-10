using Microsoft.EntityFrameworkCore;

namespace DB;

public class MonstersContext : DbContext
{
    public DbSet<Monster> Monsters { get; set; }

    public MonstersContext(DbContextOptions<MonstersContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Monster>().HasData(
            new Monster[]
            {
                new Monster{Name = "Goblin", HitPoints = 50, AttackModifier = 5, 
                    AttackPerRound = 2, Damage = 1, DamageModifier = 1, Weapon = 1, AC = 2,
                    MinACtoAlwaysHit = 7, DamagePerRound = 6
                },
                new Monster{Name = "Griffon", HitPoints = 50, AttackModifier = 5, 
                    AttackPerRound = 2, Damage = 1, DamageModifier = 1, Weapon = 1, AC = 2,
                    MinACtoAlwaysHit = 7, DamagePerRound = 6
                },
                new Monster{Name = "Elf", HitPoints = 50, AttackModifier = 5, 
                    AttackPerRound = 2, Damage = 1, DamageModifier = 1, Weapon = 1, AC = 2,
                    MinACtoAlwaysHit = 7, DamagePerRound = 6
                },
            });
    } 
}