using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoFeedback360.Migrations
{
    /// <inheritdoc />
    public partial class altertablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__dbRoleDetails",
                table: "_dbRoleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK__dbDesignationDetails",
                table: "_dbDesignationDetails");

            migrationBuilder.RenameTable(
                name: "_dbRoleDetails",
                newName: "UserRoleDetails");

            migrationBuilder.RenameTable(
                name: "_dbDesignationDetails",
                newName: "UserDesignationDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleDetails",
                table: "UserRoleDetails",
                column: "Role_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDesignationDetails",
                table: "UserDesignationDetails",
                column: "DesignationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleDetails",
                table: "UserRoleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDesignationDetails",
                table: "UserDesignationDetails");

            migrationBuilder.RenameTable(
                name: "UserRoleDetails",
                newName: "_dbRoleDetails");

            migrationBuilder.RenameTable(
                name: "UserDesignationDetails",
                newName: "_dbDesignationDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK__dbRoleDetails",
                table: "_dbRoleDetails",
                column: "Role_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__dbDesignationDetails",
                table: "_dbDesignationDetails",
                column: "DesignationId");
        }
    }
}
