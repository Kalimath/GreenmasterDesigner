using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantThresholds
{
    // ReSharper disable once TooManyDependencies
    public PlantThresholds(bool zeroMeansAny, Lifecycle cycle, double metricHeightMax, double metricHeightMin,
        double metricDiameterMin, double metricDiameterMax, bool hedgeable)
    {
        try
        {
            Hedgeable = hedgeable;
            ZeroMeansAny = zeroMeansAny;
            Cycle = cycle;
            SetHeightMinMax(metricHeightMin, metricHeightMax);
            SetDiameterMinMax(metricDiameterMin, metricDiameterMax);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw;
        }
    }

    public double MetricHeightMax { get; set; }
    public double MetricHeightMin { get; set; }
    public double MetricDiameterMin { get; set; }
    public double MetricDiameterMax { get; set; }
    public bool ZeroMeansAny { get; }
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }

    private void SetDiameterMinMax(double metricDiameterMin, double metricDiameterMax)
    {
        if (metricDiameterMin > 0 && metricDiameterMin <= metricDiameterMax)
        {
            MetricDiameterMin = metricDiameterMin;
            MetricDiameterMax = metricDiameterMax;
        }
        else
        {
            throw new InvalidRangeException("minDiameter can't be lower than zero or higher than maxDiameter");
        }
    }

    private void SetHeightMinMax(double metricHeightMin, double metricHeightMax)
    {
        if (metricHeightMin > 0 && metricHeightMin <= metricHeightMax)
        {
            MetricHeightMax = metricHeightMax;
            MetricHeightMin = metricHeightMin;
        }
        else
        {
            throw new InvalidRangeException("minHeight can't be lower than zero or higher than maxHeight");
        }
    }

    public bool SpecieMeetsThresholds(Specie specie)
    {
        return SpeciePropertiesMeetThreshold(specie) && SpecieDimensionsMeetThreshold(specie);
    }

    private bool SpecieDimensionsMeetThreshold(Specie specie)
    {
        var res = true;
        var heightMeetsThreshold = HeightMeetsThreshold(specie.Dimensions.MetricHeight);
        var diameterMeetsThreshold = DiameterMeetsThreshold(specie.Dimensions.MetricDiameter);

        if (!heightMeetsThreshold || !diameterMeetsThreshold)
            res = false;

        return res;
    }

    private bool DiameterMeetsThreshold(double metricDiameter)
    {
        var diameterMeetsThreshold = MeetsMaxThreshold(MetricDiameterMax, metricDiameter) &&
                                     MeetsMinThreshold(MetricDiameterMin, metricDiameter);
        if (!diameterMeetsThreshold)
            throw new InvalidRangeException(
                $"Specie's diameter doesn't meet requirements. Min: {MetricDiameterMin} Max: {MetricDiameterMax} Actual: {metricDiameter}");
        return diameterMeetsThreshold;
    }

    private bool HeightMeetsThreshold(double metricHeight)
    {
        var heightMeetsThreshold = MeetsMaxThreshold(MetricHeightMax, metricHeight) &&
                                   MeetsMinThreshold(MetricHeightMin, metricHeight);
        if (!heightMeetsThreshold)
            throw new InvalidRangeException(
                $"Specie's height doesn't meet requirements. Min: {MetricHeightMin} Max: {MetricHeightMax} Actual: {metricHeight}");
        return heightMeetsThreshold;
    }

    private bool SpeciePropertiesMeetThreshold(Specie specie)
    {
        var res = false;
        var specieProperties = specie.Properties;

        if (specieProperties.Hedgeable == Hedgeable)
            if (Cycle == Lifecycle.NotSpecified || specieProperties.Cycle == Cycle)
                res = true;

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