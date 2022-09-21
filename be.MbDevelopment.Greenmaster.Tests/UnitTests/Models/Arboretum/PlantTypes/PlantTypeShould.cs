using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum.PlantTypes;

public class PlantTypeShould
{
    private readonly double _metricHeight;
    private readonly double _metricDiameter;
    private readonly bool _hedgeable;
    private readonly Lifecycle _lifecycle;

    public PlantTypeShould()
    {
        _metricHeight = 2.2;
        _metricDiameter = 0.6;
        _hedgeable = true;
        _lifecycle = Lifecycle.Annual;
    }

    [Fact]
    public void ThrowThresholdExceptionWhenSpecieIsNotValid()
    {
        Assert.Throws<ThresholdException>(() =>
        {
            var invalidPlantThresholds = new Tree(new Specie("Strelitzia Reginae",
                new EnumVDictionary<Language, string>(), 
                new PlantProperties(_hedgeable, _lifecycle),
                new PlantDimensions(_metricHeight, _metricDiameter)));
        });
    }
}