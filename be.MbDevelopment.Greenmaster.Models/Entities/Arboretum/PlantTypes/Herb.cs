using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Herb : Bush
{
    public Herb(Specie specie, Position place) : base(specie, place)
    {
    }
}