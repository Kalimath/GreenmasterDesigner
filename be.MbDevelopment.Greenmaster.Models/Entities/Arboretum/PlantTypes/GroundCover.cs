using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class GroundCover : Plant
{
    public GroundCover(Specie specie, Position location = null!) : base(specie, location)
    {
    }
}