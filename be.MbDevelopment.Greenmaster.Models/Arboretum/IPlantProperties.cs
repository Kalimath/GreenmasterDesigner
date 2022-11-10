using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public interface IPlantProperties
{
    bool Hedgeable { get; }
    Lifecycle Cycle { get; }
}