using System.ComponentModel;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class FloweringInfo
{
    [DisplayName("Fragrant")] public bool IsFragrant { get; set; }
    [DisplayName("Attracts pollinators")] public bool AttractsPollinators { get; set; }
    [DisplayName("Flower colors")] public Color[] FlowerColors { get; set; }
    [DisplayName("Flowering period")] public Month[] FloweringPeriod { get; set; }

    public FloweringInfo(bool isFragrant, Color[] flowerColors, Month[] floweringPeriod,
        bool attractsPollinators = true)
    {
        IsFragrant = isFragrant;
        AttractsPollinators = attractsPollinators;
        FlowerColors = flowerColors;
        FloweringPeriod = floweringPeriod;
    }
}