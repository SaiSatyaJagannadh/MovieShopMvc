using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository:BaseRepository<Movie>,IMovieRepository
{
    //top20GrossingMovies it is implemented in IRepository
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }

    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies=_dbcontext.Movies.OrderByDescending(m=>m.Revenue).Take(100);
        return movies;
    }
    
    public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
    {
        var movies = await _dbcontext.Movies.Include(m => m.Genres)
            .Where(g => g.Id == genreId).ToListAsync();
        return movies;
    }


    public async Task<Movie> GetMovieDetails(int id)
    {
        return await _dbcontext.Movies
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    
}