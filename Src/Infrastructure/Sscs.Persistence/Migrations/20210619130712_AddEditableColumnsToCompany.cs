using Microsoft.EntityFrameworkCore.Migrations;

namespace Sscs.Persistence.Migrations
{
    public partial class AddEditableColumnsToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyUserId",
                table: "Companies",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Companies",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Companies",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Companies",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Companies",
                newName: "ModifyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Companies",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Companies",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Companies",
                newName: "CreateDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);
        }
    }
}
