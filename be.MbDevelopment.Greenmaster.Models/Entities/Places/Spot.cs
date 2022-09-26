namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public class Spot : Space
{
    public double Diameter { get; }

    public Spot(Position outerA, double diameter) : base(outerA, outerA)
    {
        Diameter = diameter;
    }

    public Spot(Position outerA, Position outerB) : base(outerA, outerB)
    {
        Diameter = (AbsDiffCoordinates(true)+AbsDiffCoordinates(false))/2;
    }

    public Spot() : base(new Position(),new Position())
    {
    }

    public double GetRadius()
    {
        return Diameter / 2;
    }

    public override double GetSurface()
    {
        return Math.PI * GetRadius() * GetRadius();
    }

    public override Space GetAbsolute()
    {
        return new Spot((
            new Position(OuterA.X - GetRadius(), (OuterA.Y - GetRadius()))),
            new Position(OuterA.X + GetRadius(), (OuterA.Y + GetRadius())));
    }

    public override Space GetRelative()
    {
        return new Spot(
            new Position(OuterA.X - GetRadius(), (OuterA.Y - GetRadius())),
            new Position(OuterB.X + GetRadius(), (OuterB.Y + GetRadius())));
    }
}