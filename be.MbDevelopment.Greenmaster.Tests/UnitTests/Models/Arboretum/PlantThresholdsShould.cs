using be.MbDevelopment.Greenmaster.Models.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum;

public class PlantThresholdsShould
{
    private readonly PlantThresholds _validPlantThresholds;
    private readonly double _metricHeight;
    private readonly double _metricDiameter;
    private readonly bool _hedgeable;
    private readonly Lifecycle _lifecycle;

    public PlantThresholdsShould()
    {
        _metricHeight = 2.2;
        _metricDiameter = 0.6;
        _hedgeable = true;
        _lifecycle = Lifecycle.Annual;
        _validPlantThresholds = new PlantThresholds(new PlantDimensions(_metricHeight,_metricDiameter), new PlantProperties(_hedgeable, _lifecycle));
    }

    [Fact]
    public void InitPlantDimensionsCorrectlyWhenPassedByCtor()
    {
        Assert.Equal(_metricHeight, _validPlantThresholds.RequiredDimensions!.MetricHeight);
        Assert.Equal(_metricDiameter, _validPlantThresholds.RequiredDimensions.MetricDiameter);
    }
    [Fact]
    public void InitPlantPropertiesCorrectlyWhenPassedByCtor()
    {
        Assert.Equal(_hedgeable, _validPlantThresholds.RequiredProperties!.Hedgeable);
        Assert.Equal(_lifecycle, _validPlantThresholds.RequiredProperties.Cycle);
    }
    [Fact]
    public void InitPlantPropertiesCorrectlyWhenPassedByCtorAndPropsNull()
    {
        Assert.Equal(_hedgeable, _validPlantThresholds.RequiredProperties!.Hedgeable);
        Assert.Equal(_lifecycle, _validPlantThresholds.RequiredProperties.Cycle);
    }
    
}