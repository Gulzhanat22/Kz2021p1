using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class FixCelebrityNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityNews_TvCelebrities_CelebrityId",
                table: "CelebrityNews");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityNews_TvProgrammes_ProgrammeId",
                table: "CelebrityNews");

            migrationBuilder.DropIndex(
                name: "IX_CelebrityNews_CelebrityId",
                table: "CelebrityNews");

            migrationBuilder.DropIndex(
                name: "IX_CelebrityNews_ProgrammeId",
                table: "CelebrityNews");

            migrationBuilder.AlterColumn<long>(
                name: "ProgrammeId",
                table: "CelebrityNews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CelebrityId",
                table: "CelebrityNews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityNews_CelebrityId",
                table: "CelebrityNews",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityNews_ProgrammeId",
                table: "CelebrityNews",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityNews_TvCelebrities_CelebrityId",
                table: "CelebrityNews",
                column: "CelebrityId",
                principalTable: "TvCelebrities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityNews_TvProgrammes_ProgrammeId",
                table: "CelebrityNews",
                column: "ProgrammeId",
                principalTable: "TvProgrammes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityNews_TvCelebrities_CelebrityId",
                table: "CelebrityNews");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityNews_TvProgrammes_ProgrammeId",
                table: "CelebrityNews");

            migrationBuilder.DropIndex(
                name: "IX_CelebrityNews_CelebrityId",
                table: "CelebrityNews");

            migrationBuilder.DropIndex(
                name: "IX_CelebrityNews_ProgrammeId",
                table: "CelebrityNews");

            migrationBuilder.AlterColumn<long>(
                name: "ProgrammeId",
                table: "CelebrityNews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CelebrityId",
                table: "CelebrityNews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityNews_TvCelebrities_CelebrityId",
                table: "CelebrityNews",
                column: "CelebrityId",
                principalTable: "TvCelebrities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityNews_TvProgrammes_ProgrammeId",
                table: "CelebrityNews",
                column: "ProgrammeId",
                principalTable: "TvProgrammes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
