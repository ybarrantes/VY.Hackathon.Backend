using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Dto;
using VY.Hackathon.Backend.Domain.Poco;

namespace VY.Hackathon.Backend.Business;

public class HandlingService : IHandlingService
{
    public HandlingService()
    {
        
    }

    public async Task<OperationResult<IEnumerable<HandlingDto>>> GetHandlingByDateRange(DateTime startDate, DateTime endDate)
    {
        var mockResult = new List<HandlingDto>
        {
            new HandlingDto
            {
                Day = new DateTime(2023, 2, 21),
                Hour = 6,
                HandlingFunction = "",
                TotalCost = 20,
                TotalEmployees = 1,
                FullTimeCost = 30,
                FullTimeEmployees = 10,
                PartTimeCost = 50.5m,
                PartTimeEmployees = 8
            }
        };

        return new OperationResult<IEnumerable<HandlingDto>>(mockResult);
    }
}