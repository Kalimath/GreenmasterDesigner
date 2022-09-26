namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public class Area : Space
{
    public Area(Position outerA, Position outerB) : base(outerA, outerB)
    {
    }

    public Area() : base(new Position(), new Position())
    {
    }

    public override double GetSurface()
    {
        return AbsDiffCoordinates(true) * AbsDiffCoordinates(false);
    }
    
    public override Space GetAbsolute()
    {
        return this;
    }
   
    public override Space GetRelative()
    {
        var outer1 = new Position();
        var outer2 = new Position(OuterB.X - Math.Abs(OuterA.X),OuterB.Y - Math.Abs(OuterA.Y), OuterB.Z - Math.Abs(OuterA.Z));
        
        return new Area(outer1, outer2);
    }
}