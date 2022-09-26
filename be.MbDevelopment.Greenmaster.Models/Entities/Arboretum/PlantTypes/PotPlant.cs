using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class PotPlant : Plant
{
    public PotPlant(Specie specie, PlantThresholds thresholds, Position place) : base(specie, new PlantThresholds(true, Lifecycle.NotSpecified, 0,0.01,0,1,false), place)
    {
    }
}