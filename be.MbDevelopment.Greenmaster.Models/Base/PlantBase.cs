using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

namespace be.MbDevelopment.Greenmaster.Models.Base;

public abstract class PlantBase : ObjectBase
{
    protected PlantBase(Specie specie, Position location) : base(location)
    {
        Specie = specie;
    }

    protected PlantBase(Specie specie)
    {
        Specie = specie;
    }

    public Specie Specie { get; }
}