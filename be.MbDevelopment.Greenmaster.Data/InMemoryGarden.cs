using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Tests.TestData;

namespace be.MbDevelopment.Greenmaster.Data;

public class InMemoryGarden
{
    public static List<Specie> Species { get; set; } = new(){SpecieTestFactory.NewSpecie()};
}