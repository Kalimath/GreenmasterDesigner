using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using Path = be.MbDevelopment.Greenmaster.Models.Entities.Places.Path;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Constructions;

public class Division : IDimensionable
{
    public Path Divider { get; set; }
    public ObjectDimensions Dimensions { get; set; }

    public Division(Path divider, ObjectDimensions dimensions)
    {
        Divider = divider;
        Dimensions = dimensions;
    }
}