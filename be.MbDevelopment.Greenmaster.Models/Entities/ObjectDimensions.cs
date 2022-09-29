using System.ComponentModel;
using System.Globalization;

namespace be.MbDevelopment.Greenmaster.Models.Entities;

public class ObjectDimensions
{
    [DisplayName("Height")]
    public double MetricHeight { get; }
    [DisplayName("Width")]
    public double MetricWidth { get; private set; }
    [DisplayName("Length")]
    public double MetricLength { get; private set; }

    public ObjectDimensions(double metricHeight = default, double metricWidth = default, double metricLength = default)
    {
        MetricLength = metricLength;
        try
        {
            ValidateMetricValue(metricHeight);
            ValidateMetricValue(metricWidth);
            MetricHeight = metricHeight;
            MetricWidth = metricWidth;
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

    public void ConvertToMetricDiameter(double validMetricLength, double validMetricWidth)
    {
        ValidateMetricValue(validMetricLength);
        ValidateMetricValue(validMetricWidth);
        var metricValueArray = new[] { validMetricLength, validMetricWidth };
        MetricWidth = metricValueArray.Average();
    }
}