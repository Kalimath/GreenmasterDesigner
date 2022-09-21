using System.Globalization;
using be.MbDevelopment.Greenmaster.Models.Exceptions;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

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

    private void ValidateMetricValue(double metricValue)
    {
        if (metricValue <= 0) throw new ArgumentOutOfRangeException(metricValue.ToString(CultureInfo.CurrentCulture));
    }

    public double MetricHeight { get; private set; }
    public double MetricDiameter { get; private set; }

    public void ConvertToMetricDiameter(double validMetricLength, double validMetricWidth)
    {
        ValidateMetricValue(validMetricLength);
        ValidateMetricValue(validMetricWidth);
        var metricValueArray = new[] { validMetricLength, validMetricWidth };
        this.MetricDiameter = metricValueArray.Average();
    }
}