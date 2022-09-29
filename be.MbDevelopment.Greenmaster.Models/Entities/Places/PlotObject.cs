

using be.MbDevelopment.Greenmaster.Models.Entities.Shapes;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public abstract class PlotObject : Polygon
{
    public IPlaceable Filler { get; set; }
    public Position? Location { get; set; }
    public ObjectDimensions Dimensions { get; set; }
    protected PlotObject(IPlaceable filler, ObjectDimensions dimensions, Position? location = default) : base(location, dimensions.MetricHeight, dimensions.MetricWidth)
    {
        Filler = filler;
        Dimensions = dimensions;
        Location = location;
    }
    
    public void MoveTo(Position location)
    {
        throw new NotImplementedException();
    }
}