using Microsoft.AspNetCore.Mvc;
using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Dto;
using VY.Hackathon.Backend.Domain.Extensions;

namespace VY.Hackathon.Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HandlingController
{
    private readonly IHandlingService _handlingService;

    public HandlingController(IHandlingService handlingService)
    {
        _handlingService = handlingService;
    }

    [HttpGet]
    public ResultDto<IEnumerable<HandlingDto>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var handlingResult = _handlingService.GetHandlingByDateRange(startDate, endDate);
        
        return handlingResult.MapToResultDto();
    }
}