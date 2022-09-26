using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Fruit : Plant
{
    public Fruit(Specie specie, Position place) : base(specie, new PlantThresholds(true, Lifecycle.NotSpecified, 0,0,0,0,false), place)
    {
    }
}