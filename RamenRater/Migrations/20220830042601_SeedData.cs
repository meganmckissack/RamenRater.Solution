using Microsoft.EntityFrameworkCore.Migrations;

namespace RamenRater.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ramens",
                columns: new[] { "RamenId", "Description", "Location", "Rating", "Restaurant", "Review", "Type" },
                values: new object[] { 1, "Soy base, Pork Broth, and Pork Belly", "Portland, OR", 5, "Wu-Rons", "I loved the tonkotsu broth and the pork belly.", "Tonkotsu" });

            migrationBuilder.InsertData(
                table: "Ramens",
                columns: new[] { "RamenId", "Description", "Location", "Rating", "Restaurant", "Review", "Type" },
                values: new object[] { 2, "Chiken and fish broth, topped with cha shu pork", "Portland, OR", 5, "Hapa Ramen", "The broth is divine", "Shoyu" });

            migrationBuilder.InsertData(
                table: "Ramens",
                columns: new[] { "RamenId", "Description", "Location", "Rating", "Restaurant", "Review", "Type" },
                values: new object[] { 3, "spice miso tare and pork broth with ginger pork crumbles", "Portland, OR", 5, "Afuri", "Super rich and delicious", "Tonkotsu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ramens",
                keyColumn: "RamenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ramens",
                keyColumn: "RamenId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ramens",
                keyColumn: "RamenId",
                keyValue: 3);
        }
    }
}
