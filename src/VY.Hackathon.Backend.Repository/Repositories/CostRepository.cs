using Microsoft.EntityFrameworkCore;
using VY.Hackathon.Backend.Domain.Entities;
using VY.Hackathon.Backend.Domain.Poco;
using VY.Hackathon.Backend.Domain.Repository;
using VY.Hackathon.Backend.Domain.Types;

namespace VY.Hackathon.Backend.Repository.Repositories;

public class CostRepository : ICostRepository
{
    private readonly AppDbContext _dbContext;

    public CostRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<OperationResult<IEnumerable<Cost>>> GetAll()
    {
        var costs = await _dbContext.Costs.ToListAsync();

        return (costs?.Count ?? 0) == 0 
            ? new OperationResult<IEnumerable<Cost>>(new ErrorResult("Not found", ErrorType.NotFound)) 
            : new OperationResult<IEnumerable<Cost>>(costs);
    }
}