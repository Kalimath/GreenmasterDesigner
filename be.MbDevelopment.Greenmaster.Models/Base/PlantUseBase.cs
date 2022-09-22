using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

namespace be.MbDevelopment.Greenmaster.Models.Base;

public abstract class PlantUseBase
{
    public Specie Specie { get; private set; }

    protected PlantUseBase(Specie specie)
    {
        Specie = specie;
    }
}