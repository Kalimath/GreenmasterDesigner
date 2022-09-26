using be.MbDevelopment.Greenmaster.Models.Entities.Places;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public class Flower : Bush
{
    public Flower(Specie specie, Position location) : base(specie, location)
    {
    }
    
    public Flower(Specie specie) : this(specie, new Position())
    {
    }
}