using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public sealed class Specie : BaseAuditableEntity, IPlaceable
{
    public Specie(PlantNaming naming, PlantProperties properties, ObjectDimensions dimensions)
    {
        try
        {
            Naming = naming;
            Properties = properties;
            Dimensions = dimensions;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public PlantNaming Naming { get; }
    public PlantProperties Properties { get; set; }
    public ObjectDimensions Dimensions { get; set; }
}