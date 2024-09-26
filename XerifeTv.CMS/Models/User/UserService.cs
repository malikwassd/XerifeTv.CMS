using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.User.Dtos.Request;
using XerifeTv.CMS.Models.User.Dtos.Response;
using XerifeTv.CMS.Models.User.Interfaces;

namespace XerifeTv.CMS.Models.User;

public class UserService : IUserService
{
  public Task<Result<string>> Register(RegisterUserRequestDto dto)
  {
    throw new NotImplementedException();
  }

  public Task<Result<LoginUserResponseDto>> Login(LoginUserRequestDto dto)
  {
    throw new NotImplementedException();
  }
}
