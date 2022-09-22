using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantProperties
{
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }
    

    public PlantProperties(bool hedgeable, Lifecycle cycle)
    {
        Hedgeable = hedgeable;
        Cycle = cycle;

    }

    private sealed class PlantPropertiesEqualityComparer : IEqualityComparer<PlantProperties>
    {
        public bool Equals(PlantProperties? x, PlantProperties? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Hedgeable == y.Hedgeable && x.Cycle == y.Cycle;
        }

        public int GetHashCode(PlantProperties obj)
        {
            return HashCode.Combine(obj.Hedgeable, (int)obj.Cycle);
        }
    }

    public static IEqualityComparer<PlantProperties> PlantPropertiesComparer { get; } = new PlantPropertiesEqualityComparer();
}