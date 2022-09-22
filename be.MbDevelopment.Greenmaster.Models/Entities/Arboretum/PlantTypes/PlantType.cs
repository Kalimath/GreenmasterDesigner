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
            if (!Thresholds.SpecieMeetsThresholds(specie))
            {
                throw new ThresholdException(
                    $"Specie \"{specie.ScientificName}\" does not meet requirements to be a {this.GetType().Name.ToLower()}.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new ThresholdException(
                $"Specie \"{specie.ScientificName}\" does not meet requirements to be a {this.GetType().Name.ToLower()}.");
        }
    }
}