using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.User.Common;
using XerifeTv.CMS.Models.User.Dtos.Request;
using XerifeTv.CMS.Models.User.Dtos.Response;
using XerifeTv.CMS.Models.User.Interfaces;

namespace XerifeTv.CMS.Models.User;

public class UserService(IUserRepository _repository) : IUserService
{
  public async Task<Result<string>> Register(RegisterUserRequestDto dto)
  {
    try
    {
      var entity = dto.ToEntity();
      entity.Password = HashPassword.Encrypt(dto.Password);

      var response = await _repository.CreateAsync(entity);
      return Result<string>.Success(response);
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<string>.Failure(error);
    }
  }

  public async Task<Result<LoginUserResponseDto>> Login(LoginUserRequestDto dto)
  {
    try
    {
      var response = await _repository.GetByUserNameAsync(dto.UserName);

      if (response is null)
        return Result<LoginUserResponseDto>.Failure(
          new Error("404", "user not found"));

      if (!HashPassword.Verify(dto.Password, response.Password))
        return Result<LoginUserResponseDto>.Failure(
          new Error("401", "unauthorized"));

      return Result<LoginUserResponseDto>.Success(
        new LoginUserResponseDto("token aqui..."));
    }
    catch (Exception ex)
    {
      var error = new Error("500", ex.InnerException?.Message ?? ex.Message);
      return Result<LoginUserResponseDto>.Failure(error);
    }
  }
}
