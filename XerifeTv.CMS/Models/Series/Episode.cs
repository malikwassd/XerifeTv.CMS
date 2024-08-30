using XerifeTv.CMS.Models.Abstractions.Entities;
using XerifeTv.CMS.Models.Abstractions.ValueObjects;

namespace XerifeTv.CMS.Models.Series;

public class Episode : Midia
{
  public int Number { get; set; }
  public int Season { get; set; }
  public Video? Video { get; set; }
}
