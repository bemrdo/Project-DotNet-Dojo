using DojoMovie.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DojoMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            Genres genres = new Genres();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/genre/movie/list?api_key=ed499126775c9ca7cc5bde18f73f0c8f&language=en-US"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    genres = JsonConvert.DeserializeObject<Genres>(apiResponse);
                }
            }
            Dictionary<int, string> dictGenre = new Dictionary<int, string>();
            for (int i = 0; i < genres.genres.Length; i++)
            {
                dictGenre.Add(genres.genres[i].id, genres.genres[i].name);
            }


            DiscoveryMovies discoveryMovies = new DiscoveryMovies();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/discover/movie?api_key=ed499126775c9ca7cc5bde18f73f0c8f"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    discoveryMovies = JsonConvert.DeserializeObject<DiscoveryMovies>(apiResponse);
                }
            }

            Dictionary<int, string> movieTrailer = new Dictionary<int, string>();
            foreach (Movies temp in discoveryMovies.results)
            {
                var tempLink = "https://api.themoviedb.org/3/movie/" + temp.id + "/videos?api_key=ed499126775c9ca7cc5bde18f73f0c8f&language=en-US";
                Videos movieVideos = new Videos();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(tempLink))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        movieVideos = JsonConvert.DeserializeObject<Videos>(apiResponse);
                    }
                }

                for (int i = 0; i < movieVideos.results.Length; i++)
                {
                    if (movieVideos.results[i].type == "Trailer")
                    {
                        movieTrailer.Add(temp.id, "https://www.themoviedb.org/video/play?key=" + movieVideos.results[i].key + "&width=900&height=506");
                        break;
                    }
                }

                if (movieTrailer.ContainsKey(temp.id) == false)
                {
                    for (int i = movieVideos.results.Length - 1; i >= 0; i--)
                    {
                        if (movieVideos.results[i].type == "Clip")
                        {
                            movieTrailer.Add(temp.id, "https://www.themoviedb.org/video/play?key=" + movieVideos.results[i].key + "&width=900&height=506");
                            break;
                        }
                    }
                }
            }

            UpcomingMovies upcomingMovies = new UpcomingMovies();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/movie/upcoming?api_key=ed499126775c9ca7cc5bde18f73f0c8f&language=en-US&page=1"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    upcomingMovies = JsonConvert.DeserializeObject<UpcomingMovies>(apiResponse);
                }
            }

            PopularMovies popularMovies = new PopularMovies();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=ed499126775c9ca7cc5bde18f73f0c8f&language=en-US&page=2"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    popularMovies = JsonConvert.DeserializeObject<PopularMovies>(apiResponse);
                }
            }

            TrendingMovies trendingMovies = new TrendingMovies();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/trending/movie/week?api_key=ed499126775c9ca7cc5bde18f73f0c8f"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trendingMovies = JsonConvert.DeserializeObject<TrendingMovies>(apiResponse);
                }
            }

            MoviesModel model = new MoviesModel();

            model.genres = dictGenre;
            model.discoveryMovies = discoveryMovies;
            model.movieTrailer = movieTrailer;
            model.upcomingMovies = upcomingMovies;
            model.popularMovies = popularMovies;
            model.trendingMovies = trendingMovies;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailAsync(int id)
        {
            var tempLink = "https://api.themoviedb.org/3/movie/" + id + "/videos?api_key=ed499126775c9ca7cc5bde18f73f0c8f&language=en-US";
            Videos movieVideos = new Videos();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(tempLink))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieVideos = JsonConvert.DeserializeObject<Videos>(apiResponse);
                }
            }
            Dictionary<int, string> movieTrailer = new Dictionary<int, string>();
            for (int i = 0; i < movieVideos.results.Length; i++)
            {
                if (movieVideos.results[i].type == "Trailer" && movieVideos.results[i].site == "YouTube")
                {
                    movieTrailer.Add(id, "https://www.youtube.com/embed/" + movieVideos.results[i].key);
                    break;
                }
            }
            if (movieTrailer.ContainsKey(id) == false)
            {
                for (int i = movieVideos.results.Length - 1; i >= 0; i--)
                {
                    if (movieVideos.results[i].type == "Clip" && movieVideos.results[i].site == "YouTube")
                    {
                        movieTrailer.Add(id, "https://www.youtube.com/embed/" + movieVideos.results[i].key);
                        break;
                    }
                }
            }
            string[] movieTrailers = new string[movieVideos.results.Length];
            for (int i = 0; i < movieVideos.results.Length; i++)
            {
                movieTrailers[i] = "https://www.themoviedb.org/video/play?key=" + movieVideos.results[i].key + "&width=900&height=506";
            }

            MoviesDetail moviesDetail = new MoviesDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.themoviedb.org/3/movie/" + id + "?api_key=ed499126775c9ca7cc5bde18f73f0c8f"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    moviesDetail = JsonConvert.DeserializeObject<MoviesDetail>(apiResponse);
                }
            }



            MoviesDetailModel model = new MoviesDetailModel();

            model.id = id;
            model.movieTrailer = movieTrailer;
            model.movieTrailers = movieTrailers;
            model.moviesDetail = moviesDetail;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
