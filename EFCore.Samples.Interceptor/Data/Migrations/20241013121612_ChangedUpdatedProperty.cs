using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Samples.Interceptor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUpdatedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Articles",
                newName: "UpdatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Articles",
                newName: "ModifiedDate");
        }
    }
}
