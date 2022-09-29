using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class PotPlant : Plant
{
    public PotPlant(Specie specie, Position location) : base(specie, location)
    {
    }
}