namespace be.MbDevelopment.Greenmaster.Models.Entities;

public interface IObjectDimensions
{
    double MetricHeight { get; set; }
    double MetricDiameter { get; set; }
    void ConvertToMetricDiameter(double validMetricLength, double validMetricWidth);
}