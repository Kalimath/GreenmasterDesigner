using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public abstract class PlantType : PlantBase
{
    public PlantType(Specie specie, PlantThresholds thresholds, Position location = null!) : base(specie, location)
    {
        Thresholds = thresholds;
        try
        {
            if (!Thresholds.SpecieMeetsThresholds(specie))
                throw new ThresholdException(
                    $"Specie \"{specie.Naming.GetScientificName()}\" does not meet requirements to be a {GetType().Name.ToLower()}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new ThresholdException(
                $"Specie \"{specie.Naming.GetScientificName()}\" does not meet requirements to be a {GetType().Name.ToLower()}.");
        }
    }

    private PlantThresholds Thresholds { get; }
}