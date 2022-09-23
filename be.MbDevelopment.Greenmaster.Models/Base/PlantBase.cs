using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

namespace be.MbDevelopment.Greenmaster.Models.Base;

public abstract class PlantBase : ObjectBase
{
    public Specie Specie { get; private set; }

    protected PlantBase(Specie specie, Position location) : base(location)
    {
        Specie = specie;
    }
    protected PlantBase(Specie specie)
    {
        Specie = specie; 
    }
}