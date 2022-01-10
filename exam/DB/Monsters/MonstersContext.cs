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
                new Monster
                {
                    Id = 1,
                    Name = "Goblin",
                    HitPoints = 59,
                    AttackModifier = 5,
                    AttackPerRound = 1,
                    Damage = 12,
                    DiceType = 4,
                    DamageModifier = 6,
                    AC = 12
                },
                new Monster
                {
                    Id = 2,
                    Name = "Ice Toad",
                    HitPoints = 32,
                    AttackModifier = 3,
                    DamageModifier = 1,
                    Damage = 1,
                    DiceType = 8,
                    AC = 11,
                    AttackPerRound = 1,
                },
                new Monster
                {
                    Id = 3,
                    Name = "Elf",
                    HitPoints = 161,
                    AttackModifier = 5,
                    AttackPerRound = 2,
                    Damage = 12,
                    DiceType = 6,
                    DamageModifier = 2,
                    AC = 17
                }
            });
    } 
}