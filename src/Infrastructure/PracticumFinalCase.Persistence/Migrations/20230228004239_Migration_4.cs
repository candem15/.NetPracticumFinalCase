using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticumFinalCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ShoppingList_ShoppingListId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_users_OwnerId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_users_UserId",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserName",
                table: "Users",
                newName: "IX_Users_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_products_ShoppingListId",
                table: "Products",
                newName: "IX_Products_ShoppingListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingList_ShoppingListId",
                table: "Products",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Users_OwnerId",
                table: "ShoppingList",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Users_UserId",
                table: "ShoppingList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingList_ShoppingListId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Users_OwnerId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Users_UserId",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserName",
                table: "users",
                newName: "IX_users_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShoppingListId",
                table: "products",
                newName: "IX_products_ShoppingListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ShoppingList_ShoppingListId",
                table: "products",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_users_OwnerId",
                table: "ShoppingList",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_users_UserId",
                table: "ShoppingList",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
