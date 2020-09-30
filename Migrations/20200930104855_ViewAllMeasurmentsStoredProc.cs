using Microsoft.EntityFrameworkCore.Migrations;

namespace UmbaniApiTest.Migrations
{
    public partial class ViewAllMeasurmentsStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"CREATE PROCEDURE [dbo].[ViewMeasurement]
                    (@MeasurementId uniqueidentifier = NULL)
                AS
                BEGIN
                   IF(@MeasurementID IS NULL) 
                      BEGIN
                        SELECT * FROM [Measurement]
                      END;
                   SELECT * FROM [Measurement] WHERE [MeasurementId] = @MeasurementId
                END";

            _ = migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
