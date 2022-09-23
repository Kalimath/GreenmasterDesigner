using System.ComponentModel.DataAnnotations;
using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class Specie : BaseAuditableEntity
{
    public PlantNaming Naming { get; }
    public PlantProperties Properties { get; set; }
    public PlantDimensions Dimensions { get; }

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
}