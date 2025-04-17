using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    //for running the values manually but we can do iut by db
    // public List<MovieCardModel> TopGrossingMovies()
    // {
    //     var v = new List<MovieCardModel>
    //     {
    //         new MovieCardModel
    //         {
    //             Id = 1,
    //             Title = "Avatar",
    //             PosterURL = "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
    //         },
    //         new MovieCardModel
    //         {
    //             Id = 2,
    //             Title = "Avengers: Endgame",
    //             PosterURL = "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
    //         },
    //         new MovieCardModel
    //         {
    //             Id = 3,
    //             Title = "Titanic",
    //             PosterURL= "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
    //         },
    //         new MovieCardModel
    //         {
    //             Id = 4,
    //             Title = "Star Wars: The Force Awakens",
    //             PosterURL = "https://m.media-amazon.com/images/I/81aA7hEEykL._AC_SY679_.jpg"
    //         },
    //         new MovieCardModel
    //         {
    //             Id = 5,
    //             Title = "Jurassic World",
    //             PosterURL = "https://m.media-amazon.com/images/I/91wY9U2y5CL._AC_SY679_.jpg"
    //         }
    //     };
    //
    //     return v;
    // }

    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public List<MovieCardModel> TopGrossingMovies()
    {
        var movies = _movieRepository.GetTop20GrossingMovies();
        var movieCardModels=new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterURL = movie.PosterUrl,

            });
        }
        return movieCardModels;
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        var movie = _movieRepository.GetById(id);
        var m = new MovieDetailsModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            Budget = movie.Budget,
            Overview = movie.Overview,
            Revenue = movie.Revenue,
            Tagline = movie.Tagline,
            TmdbUrl = movie.TmdbUrl,
            Price = movie.Price,
            ReleaseDate = movie.ReleaseDate,
            RunTime = movie.RunTime,
            
            
            
        };
        return m;

    }

    public MovieDetailsModel DeleteMovie(int id)
    {
        var  movie = _movieRepository.DeleteById(id);
        if (movie == null)
        {
            return null;
        }
        var m = new MovieDetailsModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            Budget = movie.Budget,
            Overview = movie.Overview,
            Revenue = movie.Revenue,
            Tagline = movie.Tagline,
        };
        return m;
    }

    

    // public async Task<IEnumerable<MovieDetailsModel>> GetMoviesByGenre(int genreId)
    // {
    //     var movies = await _movieRepository.GetMoviesByGenreId(genreId);
    //     if (!movies.Any())
    //         throw new Exception("No Movies Found");
    //     var response = new List<MovieDetailsModel>();
    //     foreach (var movie in movies)
    //     {
    //         response.Add(new MovieDetailsModel()
    //         {
    //             Id = movie.Id,
    //             Title = movie.Title,
    //             PosterURL = movie.PosterUrl,
    //             Revenue = movie.Revenue
    //         });
    //     }
    //     return response;
    // }

    
    public async Task<IEnumerable<MovieDetailsModel>> GetMoviesByGenre(int genreId)
    {
        var movies = await _movieRepository.GetMoviesByGenreId(genreId);

        if (!movies.Any())
            throw new Exception("No Movies Found");

        return movies.Select(movie => new MovieDetailsModel
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            Revenue = movie.Revenue
        }).ToList();
    }

    public async Task<MovieDetailsModel> GetMovieById(int id)
    {
        var movie = await _movieRepository.GetMovieDetails(id); 

        if (movie == null)
            return null;

        var movieDetails = new MovieDetailsModel
        {
            Id = movie.Id,
            PosterURL = movie.PosterUrl,
            Title = movie.Title,
            Overview = movie.Overview,
            Tagline = movie.Tagline,
            Budget = movie.Budget,
            Revenue = movie.Revenue,
            ImdbUrl = movie.ImdbUrl,
            TmdbUrl = movie.TmdbUrl,
            BackdropUrl = movie.BackdropUrl,
            OriginalLanguage = movie.OriginalLanguage,
            ReleaseDate = movie.ReleaseDate,
            RunTime = movie.RunTime,
            Price = movie.Price,
            Genres = new List<GenreModel>(),
            Casts = new List<CastResponseModel>()
        };

        if (movie.Genres != null)
        {
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
        }

        if (movie.MovieCasts != null)
        {
            foreach (var cast in movie.MovieCasts)
            {
                if (cast.Cast != null)
                {
                    movieDetails.Casts.Add(new CastResponseModel
                    {
                        Id = cast.CastId,
                        Character = cast.Character,
                        Name = cast.Cast.Name,
                        ProfilePath = cast.Cast.ProfilePath
                    });
                }
            }
        }

        return movieDetails;
    }


}