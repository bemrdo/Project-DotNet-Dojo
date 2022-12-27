namespace DojoMovie.Models
{
    public class IndexModel
    {
        public Dictionary<int, string> genres { get; set; }
        public DiscoveryMovies discoveryMovies { get; set; }
        public Dictionary<int, string> movieTrailer { get; set; }
        public UpcomingMovies upcomingMovies { get; set; }
        public TopRatedMoviews topRatedMovies { get; set; }
        public PopularMovies popularMovies { get; set; }
        public TrendingMovies trendingMovies { get; set; }
    }
}
