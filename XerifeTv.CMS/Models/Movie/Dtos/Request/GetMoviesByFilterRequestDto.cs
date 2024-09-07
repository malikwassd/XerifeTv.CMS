using XerifeTv.CMS.Models.Movie.Enums;

namespace XerifeTv.CMS.Models.Movie.Dtos.Request;

public record GetMoviesByFilterRequestDto(
  ESearchFilter Filter, 
  string Search, 
  int LimitResults, 
  int CurrentPage);
