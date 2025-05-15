

public class Grower
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Region { get; set; }

    public ICollection<HarvestItem> HarvestItems { get; set; }
}
