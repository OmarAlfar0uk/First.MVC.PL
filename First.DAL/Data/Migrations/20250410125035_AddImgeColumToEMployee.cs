using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImgeColumToEMployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Employee");
        }
    }
}
