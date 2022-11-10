using System.Globalization;

namespace be.MbDevelopment.Greenmaster.Models.Entities;

public class ObjectDimensions : IObjectDimensions
{
    public double MetricHeight { get; set; }
    public double MetricDiameter { get; set; }

    public ObjectDimensions(double metricHeight, double metricDiameter)
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

    /*public ObjectDimensions()
    {
        MetricHeight = 0;
        MetricDiameter = 0;
    }*/

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