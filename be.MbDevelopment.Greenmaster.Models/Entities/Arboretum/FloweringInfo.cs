using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.Time;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class FloweringInfo
{
    public bool IsFragrant { get; set; }
    public bool AttractsPollinators { get; set; }
    public Color[] FlowerColors { get; set; }
    public Month[] FloweringPeriod { get; set; }

    public FloweringInfo(bool isFragrant, Color[] flowerColors, Month[] floweringPeriod,
        bool attractsPollinators = true)
    {
        IsFragrant = isFragrant;
        AttractsPollinators = attractsPollinators;
        FlowerColors = flowerColors;
        FloweringPeriod = floweringPeriod;
    }
}