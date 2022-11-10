using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public class PlantProperties : IPlantProperties
{
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }
    

    public PlantProperties(bool hedgeable, Lifecycle cycle)
    {
        Hedgeable = hedgeable;
        Cycle = cycle;

    }
}