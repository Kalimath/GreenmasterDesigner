using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public abstract class PlantType : PlantUseBase
{
    private PlantThresholds Thresholds { get; set; } = null!;

    public PlantType(Specie specie) : base(specie)
    {
    }
    
    
}