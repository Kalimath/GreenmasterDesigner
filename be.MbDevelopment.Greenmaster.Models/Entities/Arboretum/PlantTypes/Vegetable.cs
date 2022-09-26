using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Vegetable : Plant
{
    public Vegetable(Specie specie, Position place) : base(specie, new PlantThresholds(true, Lifecycle.Annual, 0,0,0,0,false), place)
    {
    }
}