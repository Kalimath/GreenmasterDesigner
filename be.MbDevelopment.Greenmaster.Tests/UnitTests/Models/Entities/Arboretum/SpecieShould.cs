using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum;

public class SpecieShould
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _validCommonNameNl;
    private readonly string _validGenusName;
    private readonly string _validSpecieName;
    private readonly EnumVDictionary<Language, string> _validCommonNames;
    private readonly PlantProperties _validPlantProperties;
    private readonly PlantDimensions _validPlantDimensions;
    private readonly Language _language = Language.Nl;
    private PlantNaming _validPlantNaming;

    public SpecieShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _validPlantDimensions = new PlantDimensions(1.5, 0.5);
        _validGenusName = "Strelitzia";
        _validSpecieName = "Reginae";
        _validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new EnumVDictionary<Language, string>();
        _validCommonNames[Language.Nl.ToString()] = _validCommonNameNl;
        _validPlantNaming = new PlantNaming(_validGenusName, _validSpecieName, _validCommonNames);
        _validPlantProperties = new PlantProperties(false, Lifecycle.Annual);
    }

    [Fact]
    public void SetNamingCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia Reginae";
        Specie validSpecie = new Specie(_validPlantNaming, _validPlantProperties, _validPlantDimensions);
        Assert.Equal(validScientificName, validSpecie.Naming.GetScientificName());
    }

    [Fact]
    public void ThrowArgumentOutOfRangeExceptionWhenPlantDimensionsEmpty()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var specie = new Specie(_validPlantNaming, _validPlantProperties, new PlantDimensions(-15.8, 66));
        });
    }
}