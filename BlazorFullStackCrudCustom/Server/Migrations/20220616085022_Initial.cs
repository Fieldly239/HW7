using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrudCustom.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appilcations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appilcations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBackes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppilcationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    AppilcationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedBackes_Appilcations_AppilcationId",
                        column: x => x.AppilcationId,
                        principalTable: "Appilcations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedBackes_Votes_VoteId",
                        column: x => x.VoteId,
                        principalTable: "Votes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Appilcations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Smart Care" },
                    { 2, "", "IT Asset Manager" }
                });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "5" }
                });

            migrationBuilder.InsertData(
                table: "FeedBackes",
                columns: new[] { "Id", "AppilcationId", "AppilcationName", "Description", "VoteId" },
                values: new object[] { 1, 1, "Smart Care", "Error 404", 1 });

            migrationBuilder.InsertData(
                table: "FeedBackes",
                columns: new[] { "Id", "AppilcationId", "AppilcationName", "Description", "VoteId" },
                values: new object[] { 2, 2, "Chat Bot", "Error 405", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBackes_AppilcationId",
                table: "FeedBackes",
                column: "AppilcationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBackes_VoteId",
                table: "FeedBackes",
                column: "VoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBackes");

            migrationBuilder.DropTable(
                name: "Appilcations");

            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
