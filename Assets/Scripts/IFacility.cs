public interface IFacility
{
    public bool IsActive { get; set; }
    public FacilityType Type { get; set; }
    public int Price { get; set; }
}
