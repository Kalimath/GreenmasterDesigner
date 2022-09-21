using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public class Hedge : PlantType
{
    public Hedge(Specie specie) : base(specie, new PlantThresholds(Lifecycle.Perennial,metricHeightMax: 0.5,metricHeightMin: 0.25,metricDiameterMin: 1.2, hedgeable: true))
    {
    }
}
