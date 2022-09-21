using System.ComponentModel.DataAnnotations;
using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public class Specie
{
    [MinLength(3)] [MaxLength(20)] public string ScientificName { get; private set; }

    public EnumVDictionary<Language, string>? CommonNames { get; set; }
    public PlantProperties Properties { get; set; }
    public PlantDimensions Dimensions { get; }

    public Specie(string scientificName, EnumVDictionary<Language, string> commonNames, PlantProperties properties, PlantDimensions dimensions)
    {
        try
        {
            ScientificName = !string.IsNullOrWhiteSpace(scientificName)
                ? scientificName
                : throw new ArgumentException(nameof(scientificName));
            CommonNames = commonNames;
            Properties = properties;
            Dimensions = dimensions;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Specie(string scientificName, PlantDimensions dimensions) : this(scientificName, new EnumVDictionary<Language, string>(), null!, dimensions)
    {
    }
}