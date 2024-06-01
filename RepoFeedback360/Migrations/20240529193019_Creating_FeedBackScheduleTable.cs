using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoFeedback360.Migrations
{
    /// <inheritdoc />
    public partial class Creating_FeedBackScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_FeedBackScheduleDetails",
                columns: table => new
                {
                    FeedSchedulerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To_EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By_EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeebBack_CatagoryID = table.Column<int>(type: "int", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FeedBackScheduleDetails", x => x.FeedSchedulerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_FeedBackScheduleDetails");
        }
    }
}
