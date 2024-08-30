namespace XerifeTv.CMS.Models.Abstractions.Entities;

public abstract class Midia : BaseEntity
{
  public string Title { get; set; } = string.Empty;
  public string Synopsis { get; set; } = string.Empty;
  public string Banner { get; set; } = string.Empty;
  public string Poster { get; set; } = string.Empty;
  public string ReleaseYear { get; set; } = string.Empty;
  public int ParentalRating { get; set; } = 0;
}
