using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flags",
                columns: new [] { "Name", "Color", "Active" },
                values: new object[] { "Bueno", "Celeste", "1" }
                );

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Name", "Color", "Active" },
                values: new object[] { "Dudoso", "Amarillo", "1" }
            );

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Name", "Color", "Active" },
                values: new object[] { "Peligroso", "Negro y Rojo", "1" }
            );

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Name", "Color", "Active" },
                values: new object[] { "Prohibido", "Rojo", "1" }
            );

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Name", "Color", "Active" },
                values: new object[] { "Extraviado", "Blanco", "1" }
            );

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Name", "Color", "Active" },
                values: new object[] { "Rayos", "Negro", "1" }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Flags]", true);
        }
    }
}
