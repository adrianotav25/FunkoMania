using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunkoMania.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryType_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "fm_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 17, 46, 22, 948, DateTimeKind.Local).AddTicks(2032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 31, 18, 17, 18, 179, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "fm_Product",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "fm_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 31, 18, 17, 18, 179, DateTimeKind.Local).AddTicks(5355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 17, 46, 22, 948, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "fm_Product",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }
    }
}
