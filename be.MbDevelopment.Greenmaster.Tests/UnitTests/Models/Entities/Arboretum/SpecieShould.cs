using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum;

public class SpecieShould
{
    private readonly Language _language = Language.Nl;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly EnumVDictionary<Language, string> _validCommonNames;
    private readonly string _validGenusName;
    private readonly IObjectDimensions _validPlantDimensions;
    private readonly IPlantProperties _validPlantProperties;
    private readonly string _validSpecieName;
    private readonly INaming _validPlantNaming;
    private Month[] _validFloweringPeriod;

    public SpecieShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _validPlantDimensions = new ObjectDimensions(1.5, 0.5);
        _validGenusName = "Strelitzia";
        _validSpecieName = "Reginae";
        var validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new EnumVDictionary<Language, string>();
        _validCommonNames[Language.Nl.ToString()] = validCommonNameNl;
        _validPlantNaming = Substitute.For<INaming>();
        _validFloweringPeriod = new[]
        {
            Month.June, Month.July, Month.August
        };
        _validPlantProperties = new PlantProperties(isHedgeable: true,
            isMultiSeasonInterest: true, leafColors: new LeafColors(summer: Color.Green, autumn: Color.Green),
            floweringInfo: new FloweringInfo(false, new[] { Color.Blue, Color.Orange }, _validFloweringPeriod),
            cycle: Lifecycle.Perennial);
    }

    [Fact]
    public void SetNamingCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia Reginae";
        var validSpecie = new Specie(_validPlantNaming, _validPlantProperties, _validPlantDimensions);
        Assert.Equal(validScientificName, validSpecie.Naming.GetScientificName());
    }

    [Fact]
    public void ThrowArgumentOutOfRangeExceptionWhenPlantDimensionsEmpty()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var specie = new Specie(_validPlantNaming, _validPlantProperties, new ObjectDimensions(-15.8, 66));
        });
    }
}