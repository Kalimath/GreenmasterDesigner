namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public interface IPlantDimensions
{
    double MetricHeight { get; set; }
    double MetricDiameter { get; set; }
    void ConvertToMetricDiameter(double validMetricLength, double validMetricWidth);
}