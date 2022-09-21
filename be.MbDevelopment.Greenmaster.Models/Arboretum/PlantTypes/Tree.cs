using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

public class Tree<T> : PlantType<T> where T : Specie
{
    public Tree(T specie) : base(specie)
    {
    }
}