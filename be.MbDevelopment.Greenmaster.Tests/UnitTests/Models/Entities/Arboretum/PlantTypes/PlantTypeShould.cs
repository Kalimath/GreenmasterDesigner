using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;
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
    private PlantProperties _plantProperties;
    private Month[] _validFloweringPeriod;

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
    public void ThrowThresholdExceptionWhenSpecieIsNotValidForDefinedPlantType()
    {
        Assert.Throws<ThresholdException>(() =>
        {
            var invalidTree = new TestPlant(new Specie(_notTreeplantNaming,
                _plantProperties,
                new PlantDimensions(_metricHeight, _metricDiameter)));
        });
    }

    [Fact]
    public void CreatePlantTypeWhenSpecieIsValid()
    {
        var treeScientificName = $"{_treeGenus} {_treeSpecie}";
        var testPlantType = new TestPlant(new Specie(new PlantNaming(_treeGenus, _treeSpecie, _treeEnumVDictionary),
            _plantProperties,
            new PlantDimensions(3, 2)));
        Assert.Equal(treeScientificName, testPlantType.Specie.Naming.GetScientificName());
    }

    [Fact]
    public void SetLocationToDefaultWhenNotPassedInCtor()
    {
        var testPlantType = new TestPlant(new Specie(_treeplantNaming,
            _plantProperties,
            new PlantDimensions(3, 2)));
        Assert.Equal(new Position(),testPlantType.Place.OuterA);
    }

    [Fact]
    public void SetLocationToGivenWhenPassedInCtor()
    {
        var testLocation = new Position(55.44, 44.55, 0.5);
        var testPlantType = new TestPlant(new Specie(_treeplantNaming,
            _plantProperties,
            new PlantDimensions(3, 2)), testLocation);
        Assert.Equal(testLocation, testPlantType.Place.OuterA);
    }
}