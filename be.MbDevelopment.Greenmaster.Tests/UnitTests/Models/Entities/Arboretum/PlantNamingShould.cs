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
        var scientificName = $"{genus} {specie}";
        var plantNaming = new PlantNaming(genus, specie,
            translations);
        Assert.Equal(scientificName, plantNaming.ScientificName);
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
            var scientificName = $"{genus} {specie}";
            var plantNaming = new PlantNaming(genus, specie,
                translations);
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
            var scientificName = $"{genus} {specie}";
            var plantNaming = new PlantNaming(genus, specie,
                translations);
        });
    }
}