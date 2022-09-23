using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class GroundCover : PlantType
{
    public GroundCover(Specie specie, Position location = null!) : base(specie, new PlantThresholds(true, 
        Lifecycle.NotSpecified, 
        0.5, 
        0.05, 
        0.2, 
        0, 
        true),location)
    {
    }
}