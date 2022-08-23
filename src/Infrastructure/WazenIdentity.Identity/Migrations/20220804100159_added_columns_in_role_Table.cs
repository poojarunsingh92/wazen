using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenIdentity.Identity.Migrations
{
    public partial class added_columns_in_role_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8545a6c0-0c0c-42bb-82b0-819a9d435197");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac9605d5-fbf3-4a80-8c6a-12d8b6f92ac4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec3caf63-ce9b-4257-8de9-0738749e5f41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1962132-f5fe-47dd-9f90-97e0edb5cd90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6e6d332-3722-4c20-87b9-3e56191e6cd0");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReadPermission",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ViewPermission",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WritePermission",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbf46673-fc82-485d-a478-443c1285411f", "f3d6c359-103f-41bd-9c22-d9c9acfa68e5", "Viewer", "VIEWER" },
                    { "f627bb38-28bb-4057-a678-6af67af1b873", "fb483da6-5c60-4d9c-b1a0-54d612f3371a", "Administrator", "ADMINISTRATOR" },
                    { "3bab43c5-83de-42fe-9462-ace765608f17", "bbc81a0b-f9af-4faa-98ba-cddca07c465a", "SYSTEM_ADMIN", "SYSTEM_ADMIN" },
                    { "5bbcda6a-61f5-4670-8985-8d31a00f5ad5", "6b30bd5a-77d1-43cf-a2f6-91304e0607ee", "IC_ADMIN", "IC_ADMIN" },
                    { "bb035c0a-c549-4270-877a-497e460ed649", "c9019a37-71c3-4492-93a6-0e09b855f032", "CUSTOMER", "CUSTOMER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ReadPermission",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ViewPermission",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "WritePermission",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f1962132-f5fe-47dd-9f90-97e0edb5cd90", "173a9bff-a97b-4b55-b824-aad6e81922f0", "Viewer", "VIEWER" },
                    { "ec3caf63-ce9b-4257-8de9-0738749e5f41", "9efe5ca4-707a-4f84-8787-27f6111112ee", "Administrator", "ADMINISTRATOR" },
                    { "8545a6c0-0c0c-42bb-82b0-819a9d435197", "d8f1f523-5fb8-424b-8126-e886f64720e8", "SYSTEM_ADMIN", "SYSTEM_ADMIN" },
                    { "f6e6d332-3722-4c20-87b9-3e56191e6cd0", "07b205e1-1a5b-479c-a273-38ccefb6c083", "IC_ADMIN", "IC_ADMIN" },
                    { "ac9605d5-fbf3-4a80-8c6a-12d8b6f92ac4", "5cdb8699-6855-4eee-8a62-ff893003dcd2", "CUSTOMER", "CUSTOMER" }
                });
        }
    }
}
