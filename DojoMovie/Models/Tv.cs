namespace DojoMovie.Models
{
    public class Tv
    {
        public string? poster_path { get; set; }
        public float popularity { get; set; }
        public int id { get; set; }
        public string? backdrop_path { get; set; }
        public float vote_average { get; set; }
        public string overview { get; set; }
        public string first_air_date { get; set; }
        public string[] origin_country { get; set; }
        public int[] genre_ids { get; set; }
        public string original_language { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
    }
}
