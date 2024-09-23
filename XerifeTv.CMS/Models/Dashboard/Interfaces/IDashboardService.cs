using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Dashboard.Dtos.Response;

namespace XerifeTv.CMS.Models.Dashboard.Interfaces;

public interface IDashboardService
{
  Task<Result<GetDashboardDataRequestDto>> Get();
}
