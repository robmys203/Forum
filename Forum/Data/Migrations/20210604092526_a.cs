using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_TopicModelTematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "TopicModelTematID",
                table: "Posty",
                newName: "TematModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_TopicModelTematID",
                table: "Posty",
                newName: "IX_Posty_TematModelTematID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "766b7e07-ffe4-4e26-933b-7252a38b16be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "915f2abf-65c5-4e06-9be5-5b0f0310d8ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "755a5ae6-a55f-4509-8355-0cccec3fb2fc");

            migrationBuilder.AddForeignKey(
                name: "FK_Posty_Tematy_TematModelTematID",
                table: "Posty",
                column: "TematModelTematID",
                principalTable: "Tematy",
                principalColumn: "TematID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posty_Tematy_TematModelTematID",
                table: "Posty");

            migrationBuilder.RenameColumn(
                name: "TematModelTematID",
                table: "Posty",
                newName: "TopicModelTematID");

            migrationBuilder.RenameIndex(
                name: "IX_Posty_TematModelTematID",
                table: "Posty",
                newName: "IX_Posty_TopicModelTematID");

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
    }
}
