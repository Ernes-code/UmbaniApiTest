using Microsoft.EntityFrameworkCore.Migrations;

namespace UmbaniApiTest.Migrations
{
    public partial class AddMeasurementStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"CREATE PROCEDURE [dbo].[AddMeasurement]
                    (@PersonId uniqueidentifier,
                    @Temperature float(53),
                    @Humidity float(53),
                    @Weight float(53),
                    @Depth  float(53),
                    @Width float(53),
                    @Lenght float(53),
                    @Catagory int,
                    @Pass bit)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO [Measurement] ([MeasurementId], [Temperature], [Humidity], [Weight], [Depth], [Width], [Lenght], [Catagory], [Pass], [PersonId])
                    VALUES(NEWID(), @Temperature, @Humidity, @Weight, @Depth, @Width, @Lenght, @Catagory, @Pass, @PersonId);
                END";

            _ = migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
