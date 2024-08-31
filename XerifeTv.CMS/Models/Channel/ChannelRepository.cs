using Microsoft.Extensions.Options;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Channel.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Channel;

public sealed class ChannelRepository(IOptions<DBSettings> options) 
  : BaseRepository<ChannelEntity>(ECollection.CHANNELS, options), IChannelRepository;