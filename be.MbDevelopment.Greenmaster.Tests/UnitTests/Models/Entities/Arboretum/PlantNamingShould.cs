using System.Security.AccessControl;
using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Arboretum;

public class PlantNamingShould
{
    [Fact]
    public void CorrectlySetPropsWhenCtorIsCalled()
    {
        var translations = new EnumVDictionary<Language, string>();
        translations[Language.Nl.ToString()] = "Gewone buxus";
        const string genus = "Buxus";
        const string specie = "Sempervirens";
        string scientificName = $"{genus} {specie}";
        PlantNaming plantNaming = new PlantNaming(genus: genus, specie: specie,
            common: translations);
        Assert.Equal(scientificName, plantNaming.GetScientificName());
    }
    
    [Fact]
    public void ThrowsWhenCtorParamNamesAreEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var translations = new EnumVDictionary<Language, string>();
            translations[Language.Nl.ToString()] = "Gewone buxus";
            const string genus = "";
            const string specie = "Sempervirens";
            string scientificName = $"{genus} {specie}";
            PlantNaming plantNaming = new PlantNaming(genus: genus, specie: specie,
                common: translations);
        });
    }
    
    [Fact]
    public void ThrowsWhenCtorParamNamesArenull()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var translations = new EnumVDictionary<Language, string>();
            translations[Language.Nl.ToString()] = "Gewone buxus";
            const string genus = "Buxus";
            const string specie = null!;
            string scientificName = $"{genus} {specie}";
            PlantNaming plantNaming = new PlantNaming(genus: genus, specie: specie,
                common: translations);
        });
    }
}