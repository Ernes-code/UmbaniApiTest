using Microsoft.EntityFrameworkCore.Migrations;

namespace UmbaniApiTest.Migrations
{
    public partial class DeleteMeasurementStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"CREATE PROCEDURE [dbo].[DeleteMeasurement]
                    (@PersonId uniqueidentifier,
                     @MeasurementId uniqueidentifier)
                AS
                BEGIN
                    DELETE FROM [Measurement] WHERE [Measurement].[PersonId] = @PersonId AND [Measurement].[PersonId] = @MeasurementId
                END";

            _ = migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
