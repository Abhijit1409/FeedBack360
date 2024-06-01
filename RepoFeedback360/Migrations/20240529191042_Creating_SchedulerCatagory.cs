using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoFeedback360.Migrations
{
    /// <inheritdoc />
    public partial class Creating_SchedulerCatagory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_FeedbackCatagory",
                columns: table => new
                {
                    Catagory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FeedbackCatagory", x => x.Catagory_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_FeedbackCatagory");
        }
    }
}
