using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class TestMovieService:IMovieService
{
    public List<MovieCardModel> TopGrossingMovies()
    {
        var v = new List<MovieCardModel>
        {
            new MovieCardModel
            {
                Id = 1,
                Title = "Avatar",
                PosterURL = "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
            },
            new MovieCardModel
            {
                Id = 2,
                Title = "Avengers: Endgame",
                PosterURL = "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
            },
            new MovieCardModel
            {
                Id = 3,
                Title = "Titanic",
                PosterURL= "https://image.tmdb.org/t/p/w500/1E5baAaEse26fej7uHcjOgEE2t2.jpg\n"
            },
            new MovieCardModel
            {
                Id = 4,
                Title = "Star Wars: The Force Awakens",
                PosterURL = "https://m.media-amazon.com/images/I/81aA7hEEykL._AC_SY679_.jpg"
            },
            new MovieCardModel
            {
                Id = 5,
                Title = "Jurassic World",
                PosterURL = "https://m.media-amazon.com/images/I/91wY9U2y5CL._AC_SY679_.jpg"
            }
        };

        return v;
    
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        throw new NotImplementedException();
    }

    public MovieDetailsModel DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieDetailsModel>> GetMoviesByGenre(int genreId)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDetailsModel> GetMovieById(int id)
    {
        throw new NotImplementedException();
    }
}