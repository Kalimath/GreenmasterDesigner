using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public class PlantThresholds
{
    public PlantDimensions? RequiredDimensions { get; set; }
    public PlantProperties? RequiredProperties { get; set; }
    

    public PlantThresholds(PlantDimensions? requiredDimensions, PlantProperties? requiredProperties)
    {
        try
        {
            RequiredDimensions = requiredDimensions;
            RequiredProperties = requiredProperties;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new InvalidThresholdsException(e.Message);
        }
    }
    
}