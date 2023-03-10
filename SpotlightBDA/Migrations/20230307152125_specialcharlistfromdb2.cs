using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SpotlightBDA.Migrations
{
    /// <inheritdoc />
    public partial class specialcharlistfromdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Find",
                table: "ReplacePolicies",
                newName: "FindValue");

            migrationBuilder.AddColumn<string>(
                name: "FindDescription",
                table: "ReplacePolicies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SpecialCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCharacters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialCharacters");

            migrationBuilder.DropColumn(
                name: "FindDescription",
                table: "ReplacePolicies");

            migrationBuilder.RenameColumn(
                name: "FindValue",
                table: "ReplacePolicies",
                newName: "Find");
        }
    }
}
