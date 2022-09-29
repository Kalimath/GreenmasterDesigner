using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class LeafColors
{
    public Color Summer { get; }
    public Color Autumn { get; }

    public LeafColors(Color summer, Color autumn)
    {
        Summer = summer;
        Autumn = autumn;
    }

    public LeafColors() :this(Color.Green, Color.Brown)
    {
    }

    public bool IsEvergreen()
    {
        return Autumn == Color.Green;
    }
    
    public override string ToString()
    {
        return $"Summer: {Summer}, Autumn: {Autumn}";
    }
}