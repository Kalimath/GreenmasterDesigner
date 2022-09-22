using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Tests.TestData;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum.PlantTypes;

public class PlantTypeShould
{
    private readonly double _metricHeight;
    private readonly double _metricDiameter;
    private readonly bool _hedgeable;
    private readonly Lifecycle _lifecycle;
    private EnumVDictionary<Language, string> _notTreeEnumVDictionary;
    private EnumVDictionary<Language, string> _treeEnumVDictionary;
    private string _ValidTreeName;

    public PlantTypeShould()
    {
        _metricHeight = 2.2;
        _metricDiameter = 0.6;
        _hedgeable = true;
        _lifecycle = Lifecycle.Perennial;
        _ValidTreeName = "Fraxinus excelsior";
        _notTreeEnumVDictionary = new EnumVDictionary<Language, string>
        {
            [Language.Nl.ToString()] = "Paradijsvogelbloem"
        };
        _treeEnumVDictionary = new EnumVDictionary<Language, string>
        {
            [Language.Nl.ToString()] = "Es"
        };
    }

    [Fact]
    public void ThrowThresholdExceptionWhenSpecieIsNotValidForDefinedPlantType()
    {
        Assert.Throws<ThresholdException>(() =>
        {
            var invalidTree = new TestPlantType(new Specie("Strelitzia Reginae",
                _notTreeEnumVDictionary,
                new PlantProperties(_hedgeable, _lifecycle),
                new PlantDimensions(_metricHeight, _metricDiameter)));
        });
    }
    
    [Fact]
    public void CreatePlantTypeWhenSpecieIsValid()
    {
        //TODO: when checking what matches: if false, exception should be thrown with explanations
        var validTree = new TestPlantType(new Specie(_ValidTreeName,
            _treeEnumVDictionary,
            new PlantProperties(_hedgeable, Lifecycle.NotSpecified),
            new PlantDimensions(35, 22.5)));
        Assert.Equal(_ValidTreeName,validTree.Specie.ScientificName);
    }
}