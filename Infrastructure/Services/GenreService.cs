using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class GenreService : IGenreService
{

    private readonly IAsyncRepository _genreRepository;

    public GenreService(IAsyncRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }


    public async Task<IEnumerable<Genre>> GetAllGenres()
    {
        var genres = await _genreRepository.ListAllAsync();
        return genres;
    }

}