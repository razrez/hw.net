using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    AttackModifier = table.Column<int>(type: "int", nullable: false),
                    AttackPerRound = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false),
                    Weapon = table.Column<int>(type: "int", nullable: false),
                    AC = table.Column<int>(type: "int", nullable: false),
                    MinACtoAlwaysHit = table.Column<int>(type: "int", nullable: false),
                    DamagePerRound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Name", "AC", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "Weapon" },
                values: new object[] { "Elf", 2, 5, 2, 1, 1, 6, 50, 7, 1 });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Name", "AC", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "Weapon" },
                values: new object[] { "Goblin", 2, 5, 2, 1, 1, 6, 50, 7, 1 });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Name", "AC", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "Weapon" },
                values: new object[] { "Griffon", 2, 5, 2, 1, 1, 6, 50, 7, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
