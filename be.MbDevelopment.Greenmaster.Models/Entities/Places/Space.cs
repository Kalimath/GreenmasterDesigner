namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public abstract class Space : IEquatable<Space>
{
    public Position OuterA { get; set; }
    public Position OuterB { get; set; }

    protected Space(Position outerA, Position outerB)
    {
        OuterA = outerA;
        OuterB = outerB;
    }

    public abstract double GetSurface();

    public abstract Space GetAbsolute();

    public abstract Space GetRelative();

    /// Returns absolute difference between OuterA and OuterB coordinates based on parameter for X or Y
    public double AbsDiffCoordinates(bool forX)
    {
        return forX ? Math.Abs(OuterA.X - OuterB.X) : Math.Abs(OuterA.Y - OuterB.Y);
    }

    public bool Equals(Space? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return OuterA.Equals(other.OuterA) && OuterB.Equals(other.OuterB);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Space)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OuterA, OuterB);
    }

    public static bool operator ==(Space? left, Space? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Space? left, Space? right)
    {
        return !Equals(left, right);
    }

}