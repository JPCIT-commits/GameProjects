using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameProjects.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Engine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContributionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContributionDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContributionDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribution_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribution_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperGame",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => new { x.DevelopersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Developer_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Game_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "perry128@mail.nmc.edu", "Jack Perry" },
                    { 2, "", "Aries" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Engine", "Genre", "Platform", "Progress", "Title", "Version" },
                values: new object[,]
                {
                    { 1, "", "Arcade", "Browser", 2, "Twin Snakes", "0.1" },
                    { 2, "", "Arcade", "Browser", 2, "Paddles", "0.1" },
                    { 3, "", "Arcade", "Browser", 2, "Tag", "0.1" },
                    { 4, "", "Action Platformer", "PC", 1, "Phantom's Prey", "pre-alpha" }
                });

            migrationBuilder.InsertData(
                table: "Contribution",
                columns: new[] { "Id", "ContributionDate", "ContributionDescription", "ContributionType", "DeveloperId", "GameId", "Role" },
                values: new object[,]
                {
                    { 1, "7/17/2024", "Design Doc", "Design", 1, 4, "" },
                    { 2, "7/17/2024", "Title Logo", "Art", 2, 4, "" },
                    { 3, "7/25/2024", "Menu Theme", "Music", 1, 4, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_DeveloperId",
                table: "Contribution",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_GameId",
                table: "Contribution",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_ProjectsId",
                table: "DeveloperGame",
                column: "ProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribution");

            migrationBuilder.DropTable(
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
