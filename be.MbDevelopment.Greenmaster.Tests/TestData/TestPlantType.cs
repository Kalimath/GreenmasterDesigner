using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Tests.TestData;

public class TestPlantType : PlantType
{
    public TestPlantType(Specie specie) : base(specie, new PlantThresholds(true, 
        Lifecycle.NotSpecified, 
        0, 
        0.25, 
        1.2, 
        0, 
        true))
    {
    }
}