using be.MbDevelopment.Greenmaster.Models.Base;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum.PlantTypes;

public abstract class Plant : IPlaceable
{
    public virtual Specie Specie { get; }
    private PlantThresholds Thresholds { get; }
    public Space Place { get; set; }
    public ObjectDimensions Dimensions { get; set; }

    public Plant(Specie specie, PlantThresholds thresholds, Position place)
    {
        Specie = specie;
        Thresholds = thresholds;
        Dimensions = new ObjectDimensions(thresholds.MetricHeightMin, thresholds.MetricDiameterMin);
        Place = new Spot(place, specie.Dimensions.MetricDiameter);
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

    protected Plant(Specie specie, PlantThresholds thresholds) : this(specie, thresholds, new Position())
    {
    }
}