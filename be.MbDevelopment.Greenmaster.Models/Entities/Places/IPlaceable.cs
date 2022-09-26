namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public interface IPlaceable : IDimensionable
{
    public Space Place { get; set; }
}