public class HarvestItem// getters and setters for harvest iteams 
{
     public int Id { get; set; }
   public string ItemName { get; set; }
        public string Category { get; set; }
     public DateTime HarvestDate { get; set; }


        public int GrowerId { get; set; }
     public Grower Grower { get; set; }
}
