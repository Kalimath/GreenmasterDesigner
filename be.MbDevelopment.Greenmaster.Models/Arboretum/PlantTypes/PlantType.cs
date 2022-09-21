using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public abstract class PlantType<T> : PlantUseBase<T> where T : Specie
{
    public PlantType(T specie) : base(specie)
    {
    }
}