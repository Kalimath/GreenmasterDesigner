using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Hedge : PlantType
{
    public Hedge(Specie specie, Position location = null!) : base(specie, new PlantThresholds(true,
        Lifecycle.Perennial,
        0.5,
        0.25,
        1.2,
        1.2,
        true), location)
    {
    }
}