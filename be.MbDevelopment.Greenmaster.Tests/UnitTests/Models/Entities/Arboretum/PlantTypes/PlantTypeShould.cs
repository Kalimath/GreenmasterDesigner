using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;
using be.MbDevelopment.Greenmaster.Tests.TestData;
using NSubstitute;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum.PlantTypes;

public class PlantTypeShould
{
    
    private readonly EnumVDictionary<Language, string> _treeEnumVDictionary;
    private readonly INaming _validPlantNaming;
    private readonly string _treeGenus;
    private readonly string _treeSpecie;
    private IPlantProperties _validPlantProperties;
    private readonly IObjectDimensions _validObjectDimensions;

    public PlantTypeShould()
    {
        _treeGenus = "Fraxinus";
        _treeSpecie = "Excelsior";
        _treeEnumVDictionary = new EnumVDictionary<Language, string>
        {
            [Language.Nl.ToString()] = "Es"
        };
        _validPlantNaming = Substitute.For<INaming>();
        _validObjectDimensions = Substitute.For<IObjectDimensions>();
        _validPlantProperties = Substitute.For<IPlantProperties>();
    }

    [Fact]
    public void ThrowThresholdExceptionWhenSpecieIsNotValidForDefinedPlantType()
    {
        Assert.Throws<ThresholdException>(() =>
        {
            _ = new TestPlant(new Specie(_validPlantNaming,
                _validPlantProperties, _validObjectDimensions));
        });
    }

    [Fact]
    public void CreatePlantTypeWhenSpecieIsValid()
    {
        var treeScientificName = $"{_treeGenus} {_treeSpecie}";
        var testPlantType = new TestPlant(new Specie(new PlantNaming(_treeGenus, _treeSpecie, _treeEnumVDictionary),
            _validPlantProperties,
            _validObjectDimensions));
        Assert.Equal(treeScientificName, testPlantType.Specie.Naming.GetScientificName());
    }

    [Fact]
    public void SetLocationToDefaultWhenNotPassedInCtor()
    {
        var testPlantType = new TestPlant(new Specie(_validPlantNaming,
            _validPlantProperties,
            _validObjectDimensions));
        Assert.Equal(new Position(),testPlantType.Place.OuterA);
    }

    [Fact]
    public void SetLocationToGivenWhenPassedInCtor()
    {
        var testLocation = new Position(55.44, 44.55, 0.5);
        var testPlantType = new TestPlant(new Specie(_validPlantNaming,
            _validPlantProperties,
            _validObjectDimensions), testLocation);
        Assert.Equal(testLocation, testPlantType.Place.OuterA);
    }
}