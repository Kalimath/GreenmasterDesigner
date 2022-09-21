using System.Diagnostics;
using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum.PlantTypes;

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
            Console.WriteLine(e);
            throw;
        }
    }

    private bool SpecieMeetsThresholds(Specie specie)
    {
        return SpeciePropertiesMeetThreshold(specie) && SpecieDimensionsMeetThreshold(specie);
    }

    private bool SpecieDimensionsMeetThreshold(Specie specie)
    {
        bool res = false;
        
        var heightMeetsThreshold = Thresholds.MetricHeightMax >= specie.Dimensions.MetricHeight && Thresholds.MetricHeightMin <= specie.Dimensions.MetricHeight;
        var diameterMeetsThreshold = Thresholds.MetricDiameterMax >= specie.Dimensions.MetricDiameter && Thresholds.MetricDiameterMin <= specie.Dimensions.MetricDiameter;
        if (heightMeetsThreshold && diameterMeetsThreshold)
        {
            res = true;
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
}