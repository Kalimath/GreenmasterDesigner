using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public class Hedge<T> : PlantUseBase<T> where T : Specie
{
    public Hedge(T specie) : base(specie)
    {
    }
}