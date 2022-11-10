using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum;

public class SpecieCtorShould
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _validCommonNameNl;
    private readonly string _validScientificName;
    private readonly EnumVDictionary<Language, string> _validCommonNames;
    private readonly IPlantProperties _validPlantProperties;
    private readonly IObjectDimensions _validObjectDimensions;
    private readonly INaming _validNaming;
    private readonly PlantNaming _validPlantNaming;
    private readonly string _validGenusName;
    private readonly string _validSpecieName;
    private const Language Language = Greenmaster.Models.StaticData.Language.Nl;

    public SpecieCtorShould(ITestOutputHelper testOutputHelper)
    {
        _validGenusName = "Strelitsia";
        _validSpecieName = "Reginea";
        _testOutputHelper = testOutputHelper;
        _validObjectDimensions = Substitute.For<IObjectDimensions>();
        _validNaming = Substitute.For<INaming>();
        _validScientificName = $"{_validGenusName} {_validSpecieName}";
        _validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new EnumVDictionary<Language, string>();
        _validPlantProperties = Substitute.For<IPlantProperties>();
        //new PlantProperties(false, Lifecycle.Annual)

        
        _validPlantNaming = new PlantNaming(_validGenusName, _validSpecieName, _validCommonNames);
    }

    [Fact]
    public void SetScientificNameCorrectlyWhenNotNullOrEmpty()
    {
        var validSpecie = new Specie(_validPlantNaming, _validPlantProperties, _validObjectDimensions);
        Assert.Equal(_validScientificName, (validSpecie.Naming).GetScientificName());
    }

    [Fact]
    public void ThrowArgumentExceptionWhenNamingEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Specie(new PlantNaming("","", _validCommonNames), _validPlantProperties, _validObjectDimensions);
        });
    }

    [Fact]
    public void SetCommonNamesCorrectlyWhenNotNullOrEmpty()
    {
        _validCommonNames[Language.ToString()] = _validCommonNameNl;
        var validSpecie = new Specie(_validPlantNaming, _validPlantProperties, _validObjectDimensions);
        _testOutputHelper.WriteLine(_validCommonNames[Language.ToString()]);
        Assert.Equal(_validCommonNameNl, validSpecie.Naming.Common?[Language.ToString()]);
    }

    [Fact]
    public void ThrowArgumentNullExceptionWhenCommonNamesSetEmpty()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _ = new Specie(new PlantNaming("","", _validCommonNames), _validPlantProperties, _validObjectDimensions);
            _testOutputHelper.WriteLine(_validCommonNames[Language.ToString()]);
        });
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeExceptionWhenPlantDimensionsEmpty()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _ = new Specie(new PlantNaming(_validGenusName,_validSpecieName, new EnumVDictionary<Language, string>()), _validPlantProperties, _validObjectDimensions);
        });
    }

}