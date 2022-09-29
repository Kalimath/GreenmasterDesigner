using be.MbDevelopment.Greenmaster.Models.Entities.Places;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public abstract class Plant : PlotObject
{
    protected Plant(Specie specie, Position? location = default) : base(specie,
        new ObjectDimensions(specie.Dimensions.MetricHeight, specie.Dimensions.MetricWidth), location)
    {
    }
}