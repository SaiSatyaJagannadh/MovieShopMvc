using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository:BaseRepository<Genre>,IAsyncRepository
{
    public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }
    
    public Task<List<Genre>> ListAllAsync()
    {
            return  _dbcontext.Set<Genre>().ToListAsync();
    }
}