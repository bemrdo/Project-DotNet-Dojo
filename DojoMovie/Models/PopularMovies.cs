namespace DojoMovie.Models
{
    public class PopularMovies
    {
        public int page { get; set; }
        public int total_result { get; set; }
        public int total_pages { get; set; }
        public Movies[] results { get; set; }
    }
}
