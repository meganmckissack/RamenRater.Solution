
namespace RamenRater.Models
{
  public class Ramen
  {
    public int RamenId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Restaurant { get; set; }
    public string Location { get; set; }
    public int Rating { get; set; }
    public string Review { get; set; }
  }
}