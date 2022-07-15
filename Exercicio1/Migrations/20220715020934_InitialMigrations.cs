using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio1.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    relationship_type = table.Column<long>(type: "INTEGER", nullable: false),
                    customer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contact_Customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_customer_id",
                table: "contact",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
