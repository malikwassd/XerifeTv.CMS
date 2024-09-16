using XerifeTv.CMS.Models.Abstractions.ValueObjects;

namespace XerifeTv.CMS.Models.Series.Dtos.Request;

public class CreateEpisodeRequestDto
{
  public string SerieId { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string BannerUrl { get; set; } = string.Empty;
  public int Number { get; set; }
  public int Season { get; set; }
  public string VideoUrl { get; set; } = string.Empty;
  public long VideoDuration { get; set; }
  public string VideoStreamFormat { get; set; } = string.Empty;

  public Episode ToEntity()
  {
    return new Episode
    {
      Title = Title,
      BannerUrl = BannerUrl,
      Number = Number,
      Season = Season,
      Video = new Video(VideoUrl, VideoDuration, VideoStreamFormat)
    };
  }
}
