namespace XerifeTv.CMS.Models.Movie.Dtos.Response;

public class GetMoviesResponseDto
{
  public string Id { get; private set; } = string.Empty;
  public string Title { get; private set; } = string.Empty;
  public string Category { get; private set; } = string.Empty;
  public int ReleaseYear { get; private set; }
  public DateTime RegistrationDate { get; private set; }  

  public static GetMoviesResponseDto FromEntity(MovieEntity entity)
  {
    return new GetMoviesResponseDto
    {
      Id = entity.Id,
      Title = entity.Title,
      Category = entity.Category,
      ReleaseYear = entity.ReleaseYear,
      RegistrationDate = entity.CreateAt
    }; 
  }
}
