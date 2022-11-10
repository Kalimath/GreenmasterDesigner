using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities;

public interface IPlantProperties
{
    bool IsHedgeable { get; }
    Lifecycle Cycle { get; }
}