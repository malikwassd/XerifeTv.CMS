using XerifeTv.CMS.Models.Abstractions.ValueObjects;

namespace XerifeTv.CMS.Models.Movie.Dtos.Request;

public class CreateMovieRequestDto
{
  public string Title { get; private set; } = string.Empty;
  public string Synopsis { get; private set; } = string.Empty;
  public string Category { get; private set; } = string.Empty;
  public string PosterUrl { get; private set; } = string.Empty;
  public string BannerUrl { get; private set; } = string.Empty;
  public int ReleaseYear { get; private set; }
  public int ParentalRating { get; private set; }
  public float Review { get; private set; }
  public Video? Video { get; private set; }

  public MovieEntity ToEntity()
  {
    return new MovieEntity
    {
      Title = Title,
      Synopsis = Synopsis,
      Category = Category,
      PosterUrl = PosterUrl,
      BannerUrl = BannerUrl,
      ReleaseYear = ReleaseYear,
      ParentalRating = ParentalRating,
      Review = Review,
      Video = Video
    };
  }
}
