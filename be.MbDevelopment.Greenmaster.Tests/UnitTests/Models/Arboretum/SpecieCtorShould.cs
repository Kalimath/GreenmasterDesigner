using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Arboretum;
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
    private readonly IPlantDimensions _validPlantDimensions;
    private const Language Language = Greenmaster.Models.StaticData.Language.Nl;

    public SpecieCtorShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _validPlantDimensions = Substitute.For<IPlantDimensions>();
        _validScientificName = "Strelitzia reginae";
        _validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new EnumVDictionary<Language, string>();
        _validPlantProperties = Substitute.For<IPlantProperties>();
        //new PlantProperties(false, Lifecycle.Annual)
    }

    [Fact]
    public void SetScientificNameCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia reginae";
        Specie validSpecie = new Specie(validScientificName, _validPlantDimensions);
        Assert.Equal(validScientificName, validSpecie.ScientificName);
    }

    [Fact]
    public void ThrowArgumentExceptionWhenScientificNameEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Specie("", _validPlantDimensions);
        });
    }

    [Fact]
    public void SetCommonNamesCorrectlyWhenNotNullOrEmpty()
    {
        _validCommonNames[Language.ToString()] = _validCommonNameNl;
        var validSpecie = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, _validPlantDimensions);
        _testOutputHelper.WriteLine(_validCommonNames[Language.ToString()]);
        Assert.Equal(_validCommonNameNl, validSpecie.CommonNames?[Language.ToString()]);
    }

    [Fact]
    public void ThrowArgumentNullExceptionWhenCommonNamesSetEmpty()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _ = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, _validPlantDimensions);
            _testOutputHelper.WriteLine(_validCommonNames[Language.ToString()]);
        });
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeExceptionWhenPlantDimensionsEmpty()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _ = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, new PlantDimensions(-15.8, 66));
        });
    }

}