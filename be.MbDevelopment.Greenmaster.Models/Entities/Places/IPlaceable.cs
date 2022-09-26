namespace be.MbDevelopment.Greenmaster.Models.Entities.Places;

public interface IPlaceable
{
    public Space Place { get; set; }
    public ObjectDimensions Dimensions { get; set; }
}