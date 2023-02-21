using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Dto;
using VY.Hackathon.Backend.Domain.Poco;

namespace VY.Hackathon.Backend.Business;

public class CostService : ICostService
{
    public async Task<OperationResult<IEnumerable<CostDto>>> GetCosts()
    {
        var mock = new List<CostDto>
        {
            new() { EmployeeType = "JARDINERA", FullTimeCost = 6, PartTimeCost = 7.25m },
            new() { EmployeeType = "COORDINACIÓN", FullTimeCost = 10, PartTimeCost = 8.5m },
            new() { EmployeeType = "EQUIPAJE", FullTimeCost = 7.25m, PartTimeCost = 7m },
        };
        
        return new OperationResult<IEnumerable<CostDto>>(mock);
    }
}