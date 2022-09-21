using be.MbDevelopment.Greenmaster.Models.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum;

public class PlantThresholdsShould
{
    private readonly PlantThresholds _validPlantThresholds;
    private readonly double _metricHeightMin;
    private readonly double _metricDiameterMin;
    private readonly bool _hedgeable;
    private readonly Lifecycle _lifecycle;
    private readonly double _metricHeightMax;
    private readonly double _metricDiameterMax;

    public PlantThresholdsShould()
    {
        _metricHeightMin = 2.2;
        _metricDiameterMin = 0.6;
        _metricHeightMax = 5.2;
        _metricDiameterMax = 1.6;
        _hedgeable = true;
        _lifecycle = Lifecycle.Annual;
        _validPlantThresholds = new PlantThresholds(_lifecycle, _metricHeightMax, _metricHeightMin,_metricDiameterMin,_metricDiameterMax, _hedgeable);
    }

    [Fact]
    public void InitPlantDimensionsCorrectlyWhenPassedByCtor()
    {
        Assert.Equal(_metricHeightMin, _validPlantThresholds.MetricHeightMin);
        Assert.Equal(_metricHeightMax, _validPlantThresholds.MetricHeightMax);
        Assert.Equal(_metricDiameterMin, _validPlantThresholds.MetricDiameterMin);
        Assert.Equal(_metricDiameterMax, _validPlantThresholds.MetricDiameterMax);
    }
    [Fact]
    public void InitPlantPropertiesCorrectlyWhenPassedByCtor()
    {
        Assert.Equal(_hedgeable, _validPlantThresholds.Hedgeable);
        Assert.Equal(_lifecycle, _validPlantThresholds.Cycle);
    }
    [Fact]
    public void InitPlantPropertiesCorrectlyWhenPassedByCtorAndPropsNull()
    {
        Assert.Equal(_hedgeable, _validPlantThresholds.Hedgeable);
        Assert.Equal(_lifecycle, _validPlantThresholds.Cycle);
    }
    
    //TODO: test that min is smaller than max
    
}