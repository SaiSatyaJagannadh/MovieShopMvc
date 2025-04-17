using System.Collections;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository:IRepository<Movie>
{
    IEnumerable<Movie> GetTop20GrossingMovies();

    //Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
    
    Task<Movie> GetMovieDetails(int id);

    //Task<IEnumerable<Genre>> ListAllAsync();

    Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId);


}