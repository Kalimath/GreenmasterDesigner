using System.ComponentModel;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantProperties
{
    public PlantProperties(bool isHedgeable, bool isMultiSeasonInterest,
        LeafColors leafColors, FloweringInfo floweringInfo, Lifecycle cycle, AttentionLevel maintenanceLevel = AttentionLevel.Average)
    {
        IsHedgeable = isHedgeable;
        IsMultiSeasonInterest = isMultiSeasonInterest;
        MaintenanceLevel = maintenanceLevel;
        LeafColors = leafColors;
        Cycle = cycle;
    }

    public bool IsHedgeable { get; }
    public bool IsMultiSeasonInterest { get; }
    
    [DisplayName("Maintenance-level")]
    public AttentionLevel MaintenanceLevel { get; }
    public virtual LeafColors LeafColors { get; }
    
    [DisplayName("Phennology")]
    public Lifecycle Cycle { get; }

    public static IEqualityComparer<PlantProperties> PlantPropertiesComparer { get; } =
        new PlantPropertiesEqualityComparer();

    private sealed class PlantPropertiesEqualityComparer : IEqualityComparer<PlantProperties>
    {
        public bool Equals(PlantProperties? x, PlantProperties? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.IsHedgeable == y.IsHedgeable && x.Cycle == y.Cycle;
        }

        public int GetHashCode(PlantProperties obj)
        {
            return HashCode.Combine(obj.IsHedgeable, (int)obj.Cycle);
        }
    }
}