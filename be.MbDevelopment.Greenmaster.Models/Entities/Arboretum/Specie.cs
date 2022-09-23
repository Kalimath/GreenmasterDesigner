using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class Specie : BaseAuditableEntity
{
    public Specie(PlantNaming naming, PlantProperties properties, PlantDimensions dimensions)
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
    public PlantDimensions Dimensions { get; }
}