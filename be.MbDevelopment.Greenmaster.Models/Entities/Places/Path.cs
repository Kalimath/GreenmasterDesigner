using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public class Path : IDimensionable
{
    public Position[] Points { get; set; } = Array.Empty<Position>();
    public ObjectDimensions Dimensions { get; set; }

    public Path(Position[] points, ObjectDimensions dimensions)
    {
        ValidateAndSetPoints(points);
        Dimensions = dimensions;
    }

    private void ValidateAndSetPoints(Position[] points)
    {
        if (points.Distinct().Count() == points.Length)
        {
            Points = points;
        }
        else
        {
            throw new InValidPathShapeException(nameof(points), "points contains non-distinct values");
        }
    }
}