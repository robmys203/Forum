using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class addfkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_TematModelTematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "TematModelTematID",
                table: "Posty",
                newName: "tematModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_TematModelTematID",
                table: "Posty",
                newName: "IX_Posty_tematModelTematID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c8366293-e38b-4cea-8cdf-fc94dbf43011");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "184cd83c-c429-488d-bc4d-5f3e5c950dd2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "10fe54b7-6420-4f26-a165-9ca37f286d6a");

            migrationBuilder.AddForeignKey(
                name: "FK_Posty_Tematy_tematModelTematID",
                table: "Posty",
                column: "tematModelTematID",
                principalTable: "Tematy",
                principalColumn: "TematID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_tematModelTematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "tematModelTematID",
                table: "Posty",
                newName: "TematModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_tematModelTematID",
                table: "Posty",
                newName: "IX_Posty_TematModelTematID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "11b75643-d44b-43c1-8cda-6ed984dc3aed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "d4eb325e-d671-4cc3-8bc6-30c19c69793b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "46a33d49-4940-4d9d-a10e-a7550caf7f3b");

            migrationBuilder.AddForeignKey(
                name: "FK_Posty_Tematy_TematModelTematID",
                table: "Posty",
                column: "TematModelTematID",
                principalTable: "Tematy",
                principalColumn: "TematID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
