using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureServiceDatabaseImplement.Migrations
{
    public partial class UpdMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageInfos",
                table: "MessageInfos");

            migrationBuilder.RenameTable(
                name: "MessageInfos",
                newName: "MessageInfoes");

            migrationBuilder.RenameIndex(
                name: "IX_MessageInfos_ClientId",
                table: "MessageInfoes",
                newName: "IX_MessageInfoes_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageInfoes",
                table: "MessageInfoes",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageInfoes_Clients_ClientId",
                table: "MessageInfoes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageInfoes_Clients_ClientId",
                table: "MessageInfoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageInfoes",
                table: "MessageInfoes");

            migrationBuilder.RenameTable(
                name: "MessageInfoes",
                newName: "MessageInfos");

            migrationBuilder.RenameIndex(
                name: "IX_MessageInfoes_ClientId",
                table: "MessageInfos",
                newName: "IX_MessageInfos_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageInfos",
                table: "MessageInfos",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
