using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum;

public class PlantDimensionsShould
{
    private readonly double _validMetricLength;
    private readonly double _validMetricWidth;
    private readonly PlantDimensions _validPlantDimensions;

    private readonly double _validMetricHeight;

    private readonly double _validMetricDiameter;
    

    //TODO: test voor het omzetten van l & b naar diameter

    public PlantDimensionsShould()
    {
        _validMetricLength = 2;
        _validMetricWidth = 3;
        _validMetricHeight = 1.67;
        _validMetricDiameter = 1.8;
        _validPlantDimensions = new PlantDimensions(_validMetricHeight, _validMetricDiameter);
    }

    [Fact]
    public void ThrowArgumentOutOfRangeExceptionWhenHeightZeroOrBelow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new PlantDimensions(0, _validMetricDiameter));
        Assert.Throws<ArgumentOutOfRangeException>(() => new PlantDimensions(-1.67, _validMetricDiameter));
    }
    
    [Fact]
    public void SetMetricHeightWhenHeightGreaterThanZero()
    {
        Assert.Equal(_validMetricHeight,_validPlantDimensions.MetricHeight);
    }
    [Fact]
    public void SetMetricDiameterWhenHeightGreaterThanZero()
    {
        Assert.Equal(_validMetricDiameter,_validPlantDimensions.MetricDiameter);
    }
    
    [Fact]
    public void SetMetricDiameterWhenConvertToMetricDiameterIsCalledWithValidParams()
    {
        _validPlantDimensions.ConvertToMetricDiameter(_validMetricLength, _validMetricWidth);
        Assert.Equal(2.5,_validPlantDimensions.MetricDiameter);
    }
}