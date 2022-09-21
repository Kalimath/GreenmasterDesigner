using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public class Tree : PlantType 
{
    public Tree(Specie specie) : base(specie, new(Lifecycle.Perennial,metricHeightMax:150, metricDiameterMax:30, metricDiameterMin: 0.3,metricHeightMin: 0.25, hedgeable: default))
    {
    }
}