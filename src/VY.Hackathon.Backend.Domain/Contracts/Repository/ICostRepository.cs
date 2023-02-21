using VY.Hackathon.Backend.Domain.Entities;
using VY.Hackathon.Backend.Domain.Poco;

namespace VY.Hackathon.Backend.Domain.Contracts.Repository;

public interface ICostRepository
{
    Task<OperationResult<IEnumerable<Cost>>> GetAll();
}