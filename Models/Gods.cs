namespace NorseGodApi.Models
{
  public class Gods
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    //NOTE description will contain things like sphere of control, children, siblings, powers, yadda-yadda
    public string Description { get; set; }

  }

}