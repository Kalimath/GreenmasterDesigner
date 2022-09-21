using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public class Hedge : PlantType
{
    public Hedge(Specie specie) : base(specie, new PlantThresholds(true, 
                                                Lifecycle.Perennial, 
                                                0.5, 
                                                0.25, 
                                                1.2, 
                                                1.2, 
                                                true))
    {
    }
}