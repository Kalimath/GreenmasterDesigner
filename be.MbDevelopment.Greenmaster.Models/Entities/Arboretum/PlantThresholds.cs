using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantThresholds
{
    public double MetricHeightMax { get; set; }
    public double MetricHeightMin { get; set; }
    public double MetricDiameterMin { get; set; }
    public double MetricDiameterMax { get; set; }

    public bool ZeroMeansAny { get; }
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }
    
    public PlantThresholds(bool zeroMeansAny,Lifecycle cycle, double metricHeightMax, double metricHeightMin,
        double metricDiameterMin, double metricDiameterMax, bool hedgeable)
    {
        Hedgeable = hedgeable;
        ZeroMeansAny = zeroMeansAny;
        Cycle = cycle;
        MetricHeightMax = metricHeightMax;
        MetricHeightMin = metricHeightMin;
        MetricDiameterMin = metricDiameterMin;
        MetricDiameterMax = metricDiameterMax;
    }

    public bool SpecieMeetsThresholds(Specie specie)
    {
        return SpeciePropertiesMeetThreshold(specie) && SpecieDimensionsMeetThreshold(specie);
    }

    private bool SpecieDimensionsMeetThreshold(Specie specie)
    {
        bool res = true;
        
        var metricHeight = specie.Dimensions.MetricHeight;
        var metricDiameter = specie.Dimensions.MetricDiameter;
        
        bool heightMeetsThreshold = MeetsMaxThreshold(MetricHeightMax, metricHeight) &&
                                    MeetsMinThreshold(MetricHeightMin, metricHeight);

        bool diameterMeetsThreshold = MeetsMaxThreshold(MetricDiameterMax, metricDiameter) &&
                                      MeetsMinThreshold(MetricDiameterMin, metricDiameter);

        if (!heightMeetsThreshold || !diameterMeetsThreshold)
        {
            res = false;
        }

        return res;
    }

    private bool SpeciePropertiesMeetThreshold(Specie specie)
    {
        bool res = false;
        var specieProperties = specie.Properties;

        if (specieProperties.Hedgeable == Hedgeable && specieProperties.Cycle == Cycle)
        {
            res = true;
        }

        return res;
    }

    public bool MeetsMaxThreshold(double threshold, double validatable)
    {
        return (ZeroMeansAny && threshold == 0) || validatable <= threshold;
    }

    public bool MeetsMinThreshold(double threshold, double validatable)
    {
        return (ZeroMeansAny && threshold == 0) || validatable >= threshold;
    }
}