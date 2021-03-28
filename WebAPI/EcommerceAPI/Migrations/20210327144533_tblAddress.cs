using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceAPI.Migrations
{
    public partial class tblAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addressid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    phno = table.Column<long>(type: "bigint", nullable: false),
                    city = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    state = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    landmark = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.addressid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
