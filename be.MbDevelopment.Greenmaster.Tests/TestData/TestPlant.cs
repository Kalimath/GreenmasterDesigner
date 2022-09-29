using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Tests.TestData;

public class TestPlant : Plant
{
    public TestPlant(Specie specie, Position location) : base(specie,location)
    {
    }

    public TestPlant(Specie specie) : this(specie, new Position())
    {
    }
}