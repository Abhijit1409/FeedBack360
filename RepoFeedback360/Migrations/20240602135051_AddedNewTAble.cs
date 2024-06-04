using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoFeedback360.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTAble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_FEEDBACKRATINGS",
                columns: table => new
                {
                    FeedbackRatings_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BY_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q_ID = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_FEEDBACKRATINGS", x => x.FeedbackRatings_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_FEEDBACKRATINGS");
        }
    }
}
