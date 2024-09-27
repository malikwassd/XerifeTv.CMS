namespace XerifeTv.CMS.Models.User.Interfaces;

public interface ITokenService
{
  string GenerateToken(UserEntity user);
}
