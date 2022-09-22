using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantThresholds
{
    public double MetricHeightMax { get; set; }
    public double MetricHeightMin { get; set; }
    public double MetricDiameterMin { get; set; }
    public double MetricDiameterMax { get; set; }

    public bool ZeroMeansNoRestriction { get; }
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }
    
    public PlantThresholds(bool zeroMeansNoRestriction,Lifecycle cycle, double metricHeightMax, double metricHeightMin,
        double metricDiameterMin, double metricDiameterMax, bool hedgeable)
    {
        Hedgeable = hedgeable;
        ZeroMeansNoRestriction = zeroMeansNoRestriction;
        Cycle = cycle;
        MetricHeightMax = metricHeightMax;
        MetricHeightMin = metricHeightMin;
        MetricDiameterMin = metricDiameterMin;
        MetricDiameterMax = metricDiameterMax;
    }
    
    
}