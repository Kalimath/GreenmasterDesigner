using System.Drawing;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Shapes;

public abstract class Polygon
{
    public Rectangle? Bounds { get; set; }
    public Position?[] Points { get; set; }

    public Polygon(Position?[] points, Rectangle bounds = default)
    {
        Bounds = bounds;
        Points = points;
    }
    
    public Polygon(Position? location, double height, double width, Rectangle bounds = default)
    {
        Bounds = bounds;
        SetPoints(location, height, width);
    }

    private void SetPoints(Position? location, double height, double width)
    {
        this.Points = new[] { location, new Position(location.X + width, location.Y + height) };
    }
    
}