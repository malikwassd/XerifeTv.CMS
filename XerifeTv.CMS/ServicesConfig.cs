using XerifeTv.CMS.Models.Channel;
using XerifeTv.CMS.Models.Channel.Interfaces;
using XerifeTv.CMS.Models.Movie;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.Models.Series;
using XerifeTv.CMS.Models.Series.Interfaces;

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
    return services;
  }

  private static IServiceCollection AddServices(this IServiceCollection services)
  {
    services.AddScoped<IMovieService, MovieSevice>();
    services.AddScoped<ISeriesService, SeriesService>();
    services.AddScoped<IChannelService, ChannelService>();
    return services;
  }
}