using Microsoft.AspNetCore.Mvc;
using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Dto;
using VY.Hackathon.Backend.WebApi.Helpers;

namespace VY.Hackathon.Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CostsController
{
    private readonly ICostService _costService;

    public CostsController(ICostService costService)
    {
        _costService = costService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ResultDto<IEnumerable<HandlingDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var costsResult = await _costService.GetCosts();
        return costsResult.MapToApiResponse();
    }
}