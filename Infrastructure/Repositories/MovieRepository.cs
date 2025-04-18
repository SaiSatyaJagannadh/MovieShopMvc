using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository:BaseRepository<Movie>,IMovieRepository
{
    //top200GrossingMovies it is implemented in IRepository
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }

    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies=_dbcontext.Movies.OrderByDescending(m=>m.Revenue).Take(200);
        return movies;
    }
   

    
    public async Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId)
    {
        return await _dbcontext.Movies.Include(m => m.Genres)
            .Where(m => m.Genres.Any(mg => mg.Id == genreId))
            .ToListAsync();
    }


    public async Task<Movie> GetMovieDetails(int id)
    {
        return await _dbcontext.Movies
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    

    public virtual async Task<IEnumerable<Genre>> ListAllAsync()
    {
        return await _dbcontext.Set<Genre>().ToListAsync();
    }
    
}