using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Tests.TestData;

public class TestPlantType : PlantType
{
    public TestPlantType(Specie specie, Position location = null!) : base(specie, new PlantThresholds(true, 
        Lifecycle.NotSpecified, 
        12, 
        0.25, 
        1.2, 
        12, 
        true), location)
    {
    }
}