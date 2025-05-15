namespace AgriEnergyConnect.Models
{
    public class ErrorViewModel
    {
           public String? RequestId {get;set;}
       public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
