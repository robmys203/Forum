using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_tematModelTematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "tematModelTematID",
                table: "Posty",
                newName: "TopicModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_tematModelTematID",
                table: "Posty",
                newName: "IX_Posty_TopicModelTematID");

            migrationBuilder.AddColumn<int>(
                name: "TematID",
                table: "Posty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e3e77fce-8c29-46ca-8c34-fbaba88c3426");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "c724b996-931e-424a-9e0f-f1317e0d2111");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "98e5484e-71e7-46a2-9e3d-f08e76f3de4a");

            migrationBuilder.AddForeignKey(
                name: "FK_Posty_Tematy_TopicModelTematID",
                table: "Posty",
                column: "TopicModelTematID",
                principalTable: "Tematy",
                principalColumn: "TematID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_TopicModelTematID",
                table: "Posty");

            migrationBuilder.DropColumn(
                name: "TematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "TopicModelTematID",
                table: "Posty",
                newName: "tematModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_TopicModelTematID",
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
    }
}
