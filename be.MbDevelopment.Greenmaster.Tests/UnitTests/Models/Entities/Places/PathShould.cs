using be.MbDevelopment.Greenmaster.Models.Entities;
using be.MbDevelopment.Greenmaster.Models.Entities.Places;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using Xunit;
using Path = be.MbDevelopment.Greenmaster.Models.Entities.Places.Path;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Entities.Places;

public class PathShould
{
    /*[Fact]
    public void ThrowInValidPathShapeExceptionWhenAngleOfPathTooSharp()
    {
        // points are angled too sharp
        Assert.Throws<InValidPathShapeException>(() =>
        {
            var badPoints = new[]
            {
                new Position(x: 1, y: 1, 1.2),
                new Position(x: 3, y: 1, 1.2),
                new Position(x: 1, y: 1.2, 1.2),
            };
            var badPath = new Path(badPoints, new ObjectDimensions(15, 8));
        });
        
    }*/
    
    [Fact]
    public void ThrowInValidPathShapeExceptionWhenTooPointsAreEqual()
    {
        Assert.Throws<InValidPathShapeException>(() =>
        {
            // points are equal
            var badPoints = new[]
            {
                new Position(x: 1, y: 1, 1.2),
                new Position(x: 1, y: 1, 1.2),
            };
            var badPath = new Path(badPoints, new ObjectDimensions(15, 8));
        });
    }
}