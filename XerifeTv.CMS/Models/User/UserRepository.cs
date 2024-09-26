using Microsoft.Extensions.Options;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.User.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.User;

public sealed class UserRepository(IOptions<DBSettings> options)
  : BaseRepository<UserEntity>(ECollection.USERS, options), IUserRepository;
