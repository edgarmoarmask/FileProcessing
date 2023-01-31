using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SpotlightBDA.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileProcessPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileProcessPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckLimitPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartString = table.Column<string>(type: "text", nullable: false),
                    EndString = table.Column<string>(type: "text", nullable: true),
                    Find = table.Column<string>(type: "text", nullable: true),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    FileProcessPolicyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLimitPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckLimitPolicies_FileProcessPolicies_FileProcessPolicyId",
                        column: x => x.FileProcessPolicyId,
                        principalTable: "FileProcessPolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReplacePolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Find = table.Column<string>(type: "text", nullable: false),
                    Replace = table.Column<string>(type: "text", nullable: false),
                    FileProcessPolicyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplacePolicies_FileProcessPolicies_FileProcessPolicyId",
                        column: x => x.FileProcessPolicyId,
                        principalTable: "FileProcessPolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckLimitPolicies_FileProcessPolicyId",
                table: "CheckLimitPolicies",
                column: "FileProcessPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacePolicies_FileProcessPolicyId",
                table: "ReplacePolicies",
                column: "FileProcessPolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckLimitPolicies");

            migrationBuilder.DropTable(
                name: "ReplacePolicies");

            migrationBuilder.DropTable(
                name: "FileProcessPolicies");
        }
    }
}
