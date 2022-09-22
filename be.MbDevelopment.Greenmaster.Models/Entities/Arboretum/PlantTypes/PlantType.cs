using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public abstract class PlantType : PlantUseBase
{
    private PlantThresholds Thresholds { get; set; }

    public PlantType(Specie specie, PlantThresholds thresholds) : base(specie)
    {
        Thresholds = thresholds;
        try
        {
            if (!SpecieMeetsThresholds(specie))
            {
                throw new ThresholdException(
                    $"Specie \"{specie.ScientificName}\" does not meet requirements to be a {this.GetType().Name.ToLower()}.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw;
        }
    }

    private bool SpecieMeetsThresholds(Specie specie)
    {
        return SpeciePropertiesMeetThreshold(specie) && SpecieDimensionsMeetThreshold(specie);
    }

    private bool SpecieDimensionsMeetThreshold(Specie specie)
    {
        bool res = true;
        
        var metricHeight = specie.Dimensions.MetricHeight;
        var metricDiameter = specie.Dimensions.MetricDiameter;
        var zeroMeansAny = Thresholds.ZeroMeansNoRestriction;
        bool heightMeetsThreshold = MeetsMaxThreshold(Thresholds.MetricHeightMax, metricHeight, zeroMeansAny) &&
                                    MeetsMinThreshold(Thresholds.MetricHeightMin, metricHeight, zeroMeansAny);

        bool diameterMeetsThreshold = MeetsMaxThreshold(Thresholds.MetricDiameterMax, metricDiameter, zeroMeansAny) &&
                                      MeetsMinThreshold(Thresholds.MetricDiameterMin, metricDiameter, zeroMeansAny);

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

        if (specieProperties.Hedgeable == Thresholds.Hedgeable && specieProperties.Cycle == Thresholds.Cycle)
        {
            res = true;
        }

        return res;
    }

    public bool MeetsMaxThreshold(double threshold, double validatable, bool zeroMeansAny)
    {
        return (zeroMeansAny && threshold == 0) || validatable <= threshold;
    }

    public bool MeetsMinThreshold(double threshold, double validatable, bool zeroMeansAny)
    {
        return (zeroMeansAny && threshold == 0) || validatable >= threshold;
    }
}