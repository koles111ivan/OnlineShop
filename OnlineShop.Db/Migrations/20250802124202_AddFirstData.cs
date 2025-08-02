using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, 1099m, "Лактобактерии ацидофиллус, Бифидобактерии ВВ12", "/images/линекс форте.png", "Линекс форте" },
                    { 2, 1671m, "Глюкозамин", "/images/Дона.webp", "Дона" },
                    { 3, 521m, "Эвалар", "/images/Фитолакс.webp", "Фитолакс" },
                    { 4, 1939m, "Действующим веществом является адеметионин.", "/images/Гептрал.jpg", "Гептрал" },
                    { 5, 860m, "От боли в горле", "/images/тантум верде.jpg", "Тантум верде" },
                    { 6, 290m, "Таблетки от аллергии", "/images/Зодак.jpg", "Зодак" },
                    { 7, 1132m, "Спрей от солнца", "/images/Nivea_Sun.jpg", "Nivea Sun" },
                    { 8, 197m, "От боли в голове", "/images/нурофен.webp", "Нурофен" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
