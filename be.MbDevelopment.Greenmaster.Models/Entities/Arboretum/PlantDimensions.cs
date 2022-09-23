using System.Globalization;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantDimensions
{
    public PlantDimensions(double metricHeight, double metricDiameter)
    {
        try
        {
            ValidateMetricValue(metricHeight);
            ValidateMetricValue(metricDiameter);
            MetricHeight = metricHeight;
            MetricDiameter = metricDiameter;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public double MetricHeight { get; }
    public double MetricDiameter { get; private set; }

    private void ValidateMetricValue(double metricValue)
    {
        if (metricValue <= 0) throw new ArgumentOutOfRangeException(metricValue.ToString(CultureInfo.CurrentCulture));
    }

    public void ConvertToMetricDiameter(double validMetricLength, double validMetricWidth)
    {
        ValidateMetricValue(validMetricLength);
        ValidateMetricValue(validMetricWidth);
        var metricValueArray = new[] { validMetricLength, validMetricWidth };
        MetricDiameter = metricValueArray.Average();
    }
}