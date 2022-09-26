using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Spaces;

public class SpaceShould
{
    private readonly Space _validSpace;
    private readonly Space _relativeSpace;
    private readonly Position _outerA;
    private readonly Position _outerB;
    private readonly Position _relativeOuterB;
    private readonly Position _relativeOuterA;


    public SpaceShould()
    {
        _outerA = new Position(x: 1, y: 1, 1.2);
        _outerB = new Position(x: 11, y: 4, 1.2);
        _validSpace = new Area(_outerA, _outerB);
        _relativeOuterA = new Position(x: 0, y: 0, 0);
        _relativeOuterB = new Position(x: 10, y: 3, 0);
        _relativeSpace = new Area(_relativeOuterA, _relativeOuterB);
    }

    [Fact]
    public void ReturnCorrectSurfaceWhenGetSurfaceIsCalled()
    {
        Assert.Equal(30, _validSpace.GetSurface());
        Assert.Equal(0, new Area().GetSurface());
    }
    
    [Fact]
    public void ReturnCorrectAbsoluteSpaceWhenGetAbsoluteIsCalled()
    {
        Assert.Equal(_validSpace, _validSpace.GetAbsolute());
    }
    
    [Fact]
    public void ReturnCorrectRelativeSpaceWhenGetRelativeIsCalled()
    {
        Assert.Equal(_relativeSpace, _validSpace.GetRelative());
    }
}