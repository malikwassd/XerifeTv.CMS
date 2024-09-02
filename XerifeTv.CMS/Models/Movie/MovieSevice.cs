using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Dtos.Response;
using XerifeTv.CMS.Models.Movie.Interfaces;

namespace XerifeTv.CMS.Models.Movie;

public sealed class MovieSevice(IMovieRepository _repository) : IMovieService
{
  public async Task<Result<IEnumerable<GetMoviesResponseDto>>> Get()
  {
    try
    {
      var response = await _repository.GetAsync();

      return Result<IEnumerable<GetMoviesResponseDto>>
        .Success(response
          .OrderByDescending(r => r.CreateAt)
          .Select(GetMoviesResponseDto.FromEntity));
    }
    catch (Exception ex) 
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<IEnumerable<GetMoviesResponseDto>>.Failure(error);
    }
  }

  public async Task<Result<GetMovieResponseDto?>> Get(string id)
  {
    try
    {
      var response = await _repository.GetAsync(id);

      if (response is null) 
        return Result<GetMovieResponseDto?>
          .Failure(new Error("404", "content not found"));

      return Result<GetMovieResponseDto?>
        .Success(GetMovieResponseDto.FromEntity(response));
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<GetMovieResponseDto?>.Failure(error);
    }
  }

  public async Task<Result<string>> Create(CreateMovieRequestDto dto)
  {
    try
    {
      var entity = dto.ToEntity();
      entity.Id = Guid.NewGuid().ToString();

      await _repository.CreateAsync(entity);
      return Result<string>.Success(entity.Id);
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<string>.Failure(error);
    }
  }

  public async Task<Result<string>> Update(UpdateMovieRequestDto dto)
  {
    try
    {
      var entity = dto.ToEntity();

      var response = await _repository.GetAsync(entity.Id);

      if (response is null)
        return Result<string>.Failure(new Error("404", "content not found"));

      entity.CreateAt = response.CreateAt;
      entity.UpdateAt = DateTime.UtcNow;

      await _repository.UpdateAsync(entity);
      return Result<string>.Success(entity.Id);
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<string>.Failure(error);
    }
  }

  public async Task<Result<bool>> Delete(string id)
  {
    try
    {
      var response = await _repository.GetAsync(id);

      if (response is null)
        return Result<bool>.Failure(new Error("404", "content not found"));

      await _repository.DeleteAsync(id);
      return Result<bool>.Success(true);
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<bool>.Failure(error);
    }
  }
}
