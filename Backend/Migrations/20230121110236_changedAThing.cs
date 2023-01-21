using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class changedAThing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePurchase_Games_GameId",
                table: "GamePurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePurchase_Purchases_TransactionId",
                table: "GamePurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePurchase",
                table: "GamePurchase");

            migrationBuilder.RenameTable(
                name: "GamePurchase",
                newName: "GamePurchases");

            migrationBuilder.RenameIndex(
                name: "IX_GamePurchase_GameId",
                table: "GamePurchases",
                newName: "IX_GamePurchases_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePurchases",
                table: "GamePurchases",
                columns: new[] { "TransactionId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePurchases_Games_GameId",
                table: "GamePurchases",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePurchases_Purchases_TransactionId",
                table: "GamePurchases",
                column: "TransactionId",
                principalTable: "Purchases",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePurchases_Games_GameId",
                table: "GamePurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePurchases_Purchases_TransactionId",
                table: "GamePurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePurchases",
                table: "GamePurchases");

            migrationBuilder.RenameTable(
                name: "GamePurchases",
                newName: "GamePurchase");

            migrationBuilder.RenameIndex(
                name: "IX_GamePurchases_GameId",
                table: "GamePurchase",
                newName: "IX_GamePurchase_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePurchase",
                table: "GamePurchase",
                columns: new[] { "TransactionId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePurchase_Games_GameId",
                table: "GamePurchase",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePurchase_Purchases_TransactionId",
                table: "GamePurchase",
                column: "TransactionId",
                principalTable: "Purchases",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
