using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Tests.TestData;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum.PlantTypes;

public class PlantTypeShould
{
    private readonly bool _hedgeable;
    private readonly Lifecycle _lifecycle;
    private readonly double _metricDiameter;
    private readonly double _metricHeight;
    private readonly EnumVDictionary<Language, string> _notTreeEnumVDictionary;
    private readonly EnumVDictionary<Language, string> _treeEnumVDictionary;
    private readonly PlantNaming _treeplantNaming;
    private readonly PlantNaming _notTreeplantNaming;
    private readonly string _treeGenus;
    private readonly string _treeSpecie;

    public PlantTypeShould()
    {
        _metricHeight = 2.2;
        _metricDiameter = 0.6;
        _hedgeable = true;
        _lifecycle = Lifecycle.Perennial;
        _treeGenus = "Fraxinus";
        _treeSpecie = "Excelsior";
        _notTreeEnumVDictionary = new EnumVDictionary<Language, string>
        {
            [Language.Nl.ToString()] = "Gewone Buxus"
        };
        _treeEnumVDictionary = new EnumVDictionary<Language, string>
        {
            [Language.Nl.ToString()] = "Es"
        };
        _notTreeplantNaming = new PlantNaming("Buxus", "Sempervirens", _notTreeEnumVDictionary);
        _treeplantNaming = new PlantNaming(_treeGenus, _treeSpecie, _treeEnumVDictionary);
    }

    [Fact]
    public void ThrowThresholdExceptionWhenSpecieIsNotValidForDefinedPlantType()
    {
        Assert.Throws<ThresholdException>(() =>
        {
            var invalidTree = new TestPlantType(new Specie(_notTreeplantNaming,
                new PlantProperties(_hedgeable, _lifecycle),
                new PlantDimensions(_metricHeight, _metricDiameter)));
        });
    }

    [Fact]
    public void CreatePlantTypeWhenSpecieIsValid()
    {
        var treeScientificName = $"{_treeGenus} {_treeSpecie}";
        var testPlantType = new TestPlantType(new Specie(new PlantNaming(_treeGenus, _treeSpecie, _treeEnumVDictionary),
            new PlantProperties(_hedgeable, Lifecycle.NotSpecified),
            new PlantDimensions(3, 2)));
        Assert.Equal(treeScientificName, testPlantType.Specie.Naming.GetScientificName());
    }

    [Fact]
    public void SetLocationToNullWhenNotPassedInCtor()
    {
        var testPlantType = new TestPlantType(new Specie(_treeplantNaming,
            new PlantProperties(_hedgeable, Lifecycle.NotSpecified),
            new PlantDimensions(3, 2)));
        Assert.Null(testPlantType.Location);
    }

    [Fact]
    public void SetLocationToGivenWhenPassedInCtor()
    {
        var testLocation = new Position(55.44, 44.55, 0.5);
        var testPlantType = new TestPlantType(new Specie(_treeplantNaming,
            new PlantProperties(_hedgeable, Lifecycle.NotSpecified),
            new PlantDimensions(3, 2)), testLocation);
        Assert.Equal(testLocation, testPlantType.Location);
    }
}