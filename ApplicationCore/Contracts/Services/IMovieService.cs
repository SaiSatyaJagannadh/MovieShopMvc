using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    //all the business logic methoss relatingto movies
    List<MovieCardModel> TopGrossingMovies();
    
    MovieDetailsModel GetMovieDetails(int id);
    
    MovieDetailsModel DeleteMovie(int id);

    Task<IEnumerable<MovieDetailsModel>> GetMoviesByGenre(int genreId);
    
    Task<MovieDetailsModel> GetMovieById(int id);


}