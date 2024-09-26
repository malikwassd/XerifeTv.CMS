using XerifeTv.CMS.Models.Abstractions.Entities;
using XerifeTv.CMS.Models.User.Enums;

namespace XerifeTv.CMS.Models.User;

public class UserEntity : BaseEntity
{
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public EUserRole Role { get; set; } = EUserRole.COMMON;
}
