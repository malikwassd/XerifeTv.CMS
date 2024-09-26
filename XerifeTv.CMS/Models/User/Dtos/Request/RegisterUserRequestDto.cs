using XerifeTv.CMS.Models.User.Enums;

namespace XerifeTv.CMS.Models.User.Dtos.Request;

public class RegisterUserRequestDto
{
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public EUserRole Role { get; set; } = EUserRole.COMMON;

  public UserEntity ToEntity()
  {
    return new UserEntity
    {
      UserName = UserName,
      Password = Password,
      Role = Role
    };
  }
}
