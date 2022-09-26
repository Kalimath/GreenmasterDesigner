using be.MbDevelopment.Greenmaster.Models.Base;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public class Placeholder
{
    public IPlaceable Placeable { get; }

    public Placeholder(IPlaceable placeable)
    {
        
        Placeable = placeable;
    }
    
}