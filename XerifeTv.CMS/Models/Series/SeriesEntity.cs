using XerifeTv.CMS.Models.Abstractions.Entities;

namespace XerifeTv.CMS.Models.Series;

public class SeriesEntity : Midia
{
  public string Category { get; set; } = string.Empty;
  public float Review { get; set; }
  public int NumberSeasons { get; set; } = 1;
  public ICollection<Episode> Episodes { get; set; } = [];
}
