using be.MbDevelopment.Greenmaster.Models.Entities;

namespace be.MbDevelopment.Greenmaster.Models.Base;

public abstract class ObjectBase
{
    public ObjectBase(Position location = null!)
    {
        Location = location;
    }

    public Position Location { get; set; }
}