using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Series.Dtos.Request;

namespace XerifeTv.CMS.Models.Series.Interfaces;

public interface ISeriesRepository : IBaseRepository<SeriesEntity>
{
  Task<PagedList<SeriesEntity>> GetByFilterAsync(GetSeriesByFilterRequestDto dto);
  Task<string> CreateEpisodeAsync(string serieId, Episode episode);
}