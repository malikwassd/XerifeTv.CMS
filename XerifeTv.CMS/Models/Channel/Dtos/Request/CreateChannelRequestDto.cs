using XerifeTv.CMS.Models.Abstractions.ValueObjects;

namespace XerifeTv.CMS.Models.Channel.Dtos.Request;

public class CreateChannelRequestDto
{
  public string Title { get; init; } = string.Empty;
  public string Category { get; init; } = string.Empty;
  public string LogoUrl { get; init; } = string.Empty;
  public string VideoUrl { get; init; } = string.Empty;
  public long VideoDuration { get; init; }
  public string VideoStreamFormat { get; init; } = string.Empty;

  public ChannelEntity ToEntity()
  {
    return new ChannelEntity 
    {
      Title = Title,
      Category = Category,
      LogoUrl = LogoUrl,
      Video = new Video(VideoUrl, VideoDuration, VideoStreamFormat)
    };
  }
}
