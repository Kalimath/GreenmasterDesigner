using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class Specie : BaseAuditableEntity
{
    public Specie(INaming naming, IPlantProperties properties, IObjectDimensions dimensions)
    {
        try
        {
            Naming = ((PlantNaming?)naming)!;
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
    public IPlantProperties Properties { get; set; }
    public IObjectDimensions Dimensions { get; }
}