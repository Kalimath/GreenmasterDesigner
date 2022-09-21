using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public class PlantThresholds
{
    public double MetricHeightMax { get; set; }
    public double MetricHeightMin { get; set; }
    public double MetricDiameterMin { get; set; }
    public double MetricDiameterMax { get; set; }

    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }

    public PlantThresholds(Lifecycle cycle, double metricHeightMax = default, double metricHeightMin = default,
        double metricDiameterMin = default, double metricDiameterMax = default, bool hedgeable = default)
    {
        Hedgeable = hedgeable;
        Cycle = cycle;
        MetricHeightMax = metricHeightMax;
        MetricHeightMin = metricHeightMin;
        MetricDiameterMin = metricDiameterMin;
        MetricDiameterMax = metricDiameterMax;
    }
    
    
}