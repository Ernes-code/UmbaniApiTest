using Microsoft.EntityFrameworkCore.Migrations;

namespace UmbaniApiTest.Migrations
{
    public partial class UpdateMeasurementStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"CREATE PROCEDURE [dbo].[UpdateMeasurement]
                    (@MeasurementId uniqueidentifier,
                     @Temperature float(53),
                     @Humidity float(53),
                     @Weight float(53),
                     @Depth  float(53),
                     @Width float(53),
                     @Lenght float(53),
                     @Catagory int,
                     @Pass bit
                    )
                AS
                BEGIN
                    UPDATE [Measurement] SET [Temperature] = @Temperature , [Humidity] = @Humidity , [Weight] = @Weight,
                    [Depth] = @Depth, [Width] = @Width, [Lenght] = @Lenght, [Catagory] = @Catagory, [Pass] = @Pass 
                    WHERE [MeasurementId] = @MeasurementId;
                END";

            _ = migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
