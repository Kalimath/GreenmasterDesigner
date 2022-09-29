using System.Globalization;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantDimensions: ObjectDimensions
{
    public PlantDimensions(double metricHeight, double metricWidth) : base(metricHeight, metricWidth)
    {
        
    }
}