using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddCelebrityNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelebrityNews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CelebrityId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrityNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelebrityNews_TvCelebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "TvCelebrities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrityNews_TvProgrammes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "TvProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityNews_CelebrityId",
                table: "CelebrityNews",
                column: "CelebrityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityNews_ProgrammeId",
                table: "CelebrityNews",
                column: "ProgrammeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelebrityNews");
        }
    }
}
