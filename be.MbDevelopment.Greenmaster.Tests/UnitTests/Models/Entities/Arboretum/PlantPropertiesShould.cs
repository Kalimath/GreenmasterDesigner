using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum;

public class PlantPropertiesShould
{
    private readonly Month[] _validFloweringPeriod;
    private PlantProperties _plantProperties;

    public PlantPropertiesShould()
    {
        _validFloweringPeriod = new[]
        {
            Month.June, Month.July, Month.August
        };
        _plantProperties = new PlantProperties(isHedgeable: true,
            isMultiSeasonInterest: true, leafColors: new LeafColors(summer: Color.Green, autumn: Color.Green),
            floweringInfo: new FloweringInfo(false, new[] { Color.Blue, Color.Orange }, _validFloweringPeriod),
            cycle: Lifecycle.Perennial);
    }

    [Fact]
    public void SetMaintenanceLevelToAverageWhenNotSpecifiedInCtor()
    {
        Assert.Equal(AttentionLevel.Average, _plantProperties.MaintenanceLevel);
    }
}