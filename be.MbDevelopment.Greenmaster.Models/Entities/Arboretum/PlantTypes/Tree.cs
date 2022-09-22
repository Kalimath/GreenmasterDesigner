using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Tree : PlantType 
{
    public Tree(Specie specie) : base(specie, new PlantThresholds(true, 
        Lifecycle.Perennial, 
        0, 
        0.25, 
        1.2, 
        0, 
        true))
    {
    }
}