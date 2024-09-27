using XerifeTv.CMS.Models.Channel;
using XerifeTv.CMS.Models.Channel.Interfaces;
using XerifeTv.CMS.Models.Dashboard;
using XerifeTv.CMS.Models.Dashboard.Interfaces;
using XerifeTv.CMS.Models.Movie;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.Models.Series;
using XerifeTv.CMS.Models.Series.Interfaces;
using XerifeTv.CMS.Models.User;
using XerifeTv.CMS.Models.User.Interfaces;

namespace XerifeTv.CMS;

public static class ServicesConfig 
{
  public static IServiceCollection AddConfiguration(this IServiceCollection services)
  {
    services
      .AddRepositories()
      .AddServices();

    return services;
  } 

  private static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<IMovieRepository, MovieRepository>();
    services.AddScoped<ISeriesRepository, SeriesRepository>();
    services.AddScoped<IChannelRepository, ChannelRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    return services;
  }

  private static IServiceCollection AddServices(this IServiceCollection services)
  {
    services.AddScoped<IMovieService, MovieSevice>();
    services.AddScoped<ISeriesService, SeriesService>();
    services.AddScoped<IChannelService, ChannelService>();
    services.AddScoped<IDashboardService, DashboardService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ITokenService, TokenService>();
    return services;
  }
}