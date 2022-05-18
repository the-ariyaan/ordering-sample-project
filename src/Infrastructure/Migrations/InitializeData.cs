#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations;

internal static class InitializeData
{
    internal static void InsertInitialData(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "ProductType",
            columns: new[] {"Title", "Width", "StackSize", "EntityState"},
            values: new object[,]
            {
                {"PhotoBook", 19.0, 1, 0},
                {"Canvas", 16.0, 1, 0},
                {"Mug", 94.0, 4, 0},
                {"Calendar", 10.0, 1, 0},
                {"Cards", 4.7, 1, 0},
            });
    }
}