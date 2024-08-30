using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Interfaces;

namespace XerifeTv.CMS.Models.Movie;

public class MovieRepository : BaseRepository<MovieEntity>, IMovieRepository;