using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantNaming
{
    public string Genus { get; }
    public string Specie { get; }
    public EnumVDictionary<Language, string> Common { get; }

    public PlantNaming(string genus, string specie, EnumVDictionary<Language, string> common)
    {
        this.Genus = !string.IsNullOrWhiteSpace(genus)
            ? genus
            : throw new ArgumentException("Given Genus-name is not valid");

        this.Specie = !string.IsNullOrWhiteSpace(specie)
            ? specie
            : throw new ArgumentException("Given Genus-name is not valid");
        this.Common = common;
    }

    public string GetScientificName()
    {
        return $"{Genus} {Specie}";
    }
}