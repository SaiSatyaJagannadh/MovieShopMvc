using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenres();

   // Task<IEnumerable<MovieCardModel>> GetMoviesByGenre(int genreId);
}