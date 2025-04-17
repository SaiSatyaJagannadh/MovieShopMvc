using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IAsyncRepository:IRepository<Genre>
{
    Task<List<Genre>> ListAllAsync(); // return all records under certain class

}