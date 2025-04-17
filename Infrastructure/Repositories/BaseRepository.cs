using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

//created this method to use everywhee from interafce of application core 
public class BaseRepository<T>:IRepository<T> where T :class
{
    protected readonly MovieShopDbContext _dbcontext;
    //connectio with db
    public BaseRepository(MovieShopDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    
    public T Insert(T entity)
    {
     _dbcontext.Set<T>().Add(entity);
     _dbcontext.SaveChanges();
     return entity;
    }

    public T DeleteById(int id)
    {
        var entity=_dbcontext.Set<T>().Find(id);
        if (entity != null)
        {
            _dbcontext.Set<T>().Remove(entity);
            _dbcontext.SaveChanges();
            return entity;
        }
        return null;
    }

    public T Update(T entity)
    {
        _dbcontext.Entry(entity).State = EntityState.Modified;
        _dbcontext.SaveChanges();
        return entity;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbcontext.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _dbcontext.Set<T>().Find(id);
    }
}