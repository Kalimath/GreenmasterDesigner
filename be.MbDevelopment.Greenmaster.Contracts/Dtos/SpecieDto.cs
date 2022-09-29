using System.ComponentModel;

namespace be.MbDevelopment.Greenmaster.Contracts.Dtos;

public class SpecieDto
{
    [DisplayName("Multi-seasonal interest")]
    public bool IsMultiSeasonInterest { get; set; }
    [DisplayName("Maintenance-level")]
    public string MaintenanceLevel { get; set;}
    [DisplayName("Leaf-color summer")]
    public string LeafColorSummer { get; set;}
    [DisplayName("Leaf-color autumn")]
    public string LeafColorAutumn { get; set;}
    public string FloweringInfo { get; set;}
    [DisplayName("Phennology")]
    public string Cycle { get; set;}
    [DisplayName("Fragrant")] public bool IsFragrant { get; set; }
    [DisplayName("Attracts pollinators")] public bool AttractsPollinators { get; set; }
    [DisplayName("Flower colors")] public int[] FlowerColors { get; set; }
    [DisplayName("Flowering period")] public int[] FloweringPeriod { get; set; }
    [DisplayName("Height")]
    public double MetricHeight { get; set;}
    [DisplayName("Width")]
    public double MetricWidth { get; set; }
    [DisplayName("Length")]
    public double MetricLength { get; set; }
}