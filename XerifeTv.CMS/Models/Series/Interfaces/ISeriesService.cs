﻿using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Series.Dtos.Request;
using XerifeTv.CMS.Models.Series.Dtos.Response;

namespace XerifeTv.CMS.Models.Series.Interfaces;

public interface ISeriesService
{
  Task<Result<PagedList<GetSeriesResponseDto>>> Get(int currentPage, int limit);
  Task<Result<GetSeriesResponseDto?>> Get(string id);
  Task<Result<string>> Create(CreateSeriesRequestDto dto);
  Task<Result<string>> Update(UpdateSeriesRequestDto dto);
  Task<Result<bool>> Delete(string id);
  Task<Result<PagedList<GetSeriesResponseDto>>> GetByFilter(GetSeriesByFilterRequestDto dto);
  Task<Result<GetEpisodesResponseDto>> GetEpisodesBySeason(string serieId, int season);
  Task<Result<string>> CreateEpisode(CreateEpisodeRequestDto dto);
  Task<Result<string>> UpdateEpisode(UpdateEpisodeRequestDto dto);
}
