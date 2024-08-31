using Microsoft.Extensions.Options;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Series.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Series;

public sealed class SeriesRepository(IOptions<DBSettings> options) 
  : BaseRepository<SeriesEntity>(ECollection.SERIES, options), ISeriesRepository;