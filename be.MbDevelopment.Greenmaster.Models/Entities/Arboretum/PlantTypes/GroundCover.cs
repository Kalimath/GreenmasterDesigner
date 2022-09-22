using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class GroundCover : PlantType
{
    public GroundCover(Specie specie) : base(specie, new PlantThresholds(true, 
        Lifecycle.NotSpecified, 
        1.5, 
        0.05, 
        0, 
        0, 
        true))
    {
    }
}