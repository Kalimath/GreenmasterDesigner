using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Bush : Plant
{
    public Bush(Specie specie, Position location = null!) : base(specie, new PlantThresholds(true,
        Lifecycle.Perennial,
        8,
        0.2,
        0.2,
        3,
        true), location)
    {
    }
}