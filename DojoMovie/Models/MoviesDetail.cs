using Microsoft.CodeAnalysis;

namespace DojoMovie.Models
{
    public class MoviesDetail
    {
        public bool adult { get; set; }
        public string? backdrop_path { get; set; }
        public Collection belongs_to_collection { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string? homepage { get; set; }
        public int id { get; set; }
        public string? imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string? overview { get; set; }
        public float popularity { get; set; }
        public string? poster_path { get; set; }
        public Company[] production_companies { get; set; }
        public Country[] production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int? runtime { get; set; }
        public Language[] spoken_language { get; set; }
        public string status { get; set; }
        public string? tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

    }
}
