namespace DojoMovie.Models
{
    public class MoviesDetailModel
    {
        public int id { get; set; }
        public Dictionary<int, string> movieTrailer { get; set; }
        public string[] movieTrailers { get; set; }
        public MoviesDetail moviesDetail { get; set; }
    }
}
