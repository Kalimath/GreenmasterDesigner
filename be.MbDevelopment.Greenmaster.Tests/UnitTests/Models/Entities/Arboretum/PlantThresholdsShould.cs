using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum;

public class PlantThresholdsShould
{
    private readonly Lifecycle _annualLifecycle;
    private readonly bool _hedgeable;
    private readonly double _metricDiameterMax;
    private readonly double _metricDiameterMin;
    private readonly double _metricHeightMax;
    private readonly double _metricHeightMin;
    private readonly Lifecycle _notSpecifiedCycle;
    private readonly Specie _specie;
    private readonly PlantThresholds _validPlantThresholds;
    private readonly PlantProperties _plantProperties;
    private readonly Month[] _validFloweringPeriod;


    public PlantThresholdsShould()
    {
        _metricHeightMin = 2.2;
        _metricHeightMax = 5.2;
        _metricDiameterMin = 0.6;
        _metricDiameterMax = 1.6;
        _hedgeable = true;
        _annualLifecycle = Lifecycle.Annual;
        _notSpecifiedCycle = Lifecycle.NotSpecified;

        _validPlantThresholds = new PlantThresholds(true, _notSpecifiedCycle, _metricHeightMax, _metricHeightMin,
            _metricDiameterMin, _metricDiameterMax, _hedgeable);
        _validFloweringPeriod = new[]
        {
            Month.June, Month.July, Month.August
        };
        _plantProperties = new PlantProperties(isHedgeable: true,
            isMultiSeasonInterest: true, leafColors: new LeafColors(summer: Color.Green, autumn: Color.Green),
            floweringInfo: new FloweringInfo(false, new[] { Color.Blue, Color.Orange }, _validFloweringPeriod),
            cycle: Lifecycle.Perennial);
        _specie = new Specie(new PlantNaming("Buxus", "Sempervirens", new EnumVDictionary<Language, string>()),
            _plantProperties,
            new PlantDimensions(_metricHeightMin, _metricDiameterMin));
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
        Assert.Equal(_notSpecifiedCycle, _validPlantThresholds.Cycle);
    }

    [Fact]
    public void InitPlantPropertiesCorrectlyWhenPassedByCtorAndPropsNull()
    {
        Assert.Equal(_hedgeable, _validPlantThresholds.Hedgeable);
        Assert.Equal(_notSpecifiedCycle, _validPlantThresholds.Cycle);
    }

    [Fact]
    public void IgnoreLifecycleWhenNotSpecified()
    {
        Assert.True(_validPlantThresholds.SpecieMeetsThresholds(_specie));
    }

    [Fact]
    public void ThrowInvalidRangeExceptionWhenMinIsZeroInCtor()
    {
        Assert.Throws<InvalidRangeException>(() =>
        {
            var invalidMinPlantThresholds = new PlantThresholds(true, _notSpecifiedCycle, _metricHeightMax,
                _metricHeightMin,
                0, _metricDiameterMax, _hedgeable);
        });
        Assert.Throws<InvalidRangeException>(() =>
        {
            var invalidMinPlantThresholds = new PlantThresholds(true, _notSpecifiedCycle, _metricHeightMax,
                0,
                _metricDiameterMin, _metricDiameterMax, _hedgeable);
        });
    }

    [Fact]
    public void ThrowInvalidRangeExceptionWhenMinHigherThanMaxInCtor()
    {
        Assert.Throws<InvalidRangeException>(() =>
        {
            var invalidMinPlantThresholds = new PlantThresholds(true, _notSpecifiedCycle, _metricHeightMax,
                _metricHeightMin + 55,
                _metricDiameterMin + 55, _metricDiameterMax, _hedgeable);
        });
    }

    [Fact]
    public void ThrowInvalidRangeExceptionWhenMinIsNegativeInCtor()
    {
        Assert.Throws<InvalidRangeException>(() =>
        {
            var invalidMinPlantThresholds = new PlantThresholds(true, _notSpecifiedCycle, _metricHeightMax,
                _metricHeightMin - 55,
                _metricDiameterMin - 55, _metricDiameterMax, _hedgeable);
        });
    }
}