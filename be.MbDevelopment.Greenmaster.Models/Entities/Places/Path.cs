namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public class Path : IDimensionable
{
    public Position[] Points { get; set; }
    public ObjectDimensions Dimensions { get; set; }

    public Path(Position[] points, ObjectDimensions dimensions)
    {
        Points = points;
        Dimensions = dimensions;
    }
}