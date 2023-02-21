using Moq;
using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Contracts.Proxies;
using VY.Hackathon.Backend.Domain.Dto;
using VY.Hackathon.Backend.Domain.Dto.Proxies;
using VY.Hackathon.Backend.Domain.Poco;

namespace VY.Hackathon.Backend.Business.UnitTests;

public class HandlingServiceTests
{
    private readonly Mock<IHandlingProxy> _handlingProxyMock;
    private readonly Mock<ICostService> _costServiceMock;
    private readonly IHandlingService _handlingServiceSut;
    
    public HandlingServiceTests()
    {
        _handlingProxyMock = new Mock<IHandlingProxy>();
        _costServiceMock = new Mock<ICostService>();
        _handlingServiceSut = new HandlingService(_handlingProxyMock.Object, _costServiceMock.Object);
    }
    
    [Fact]
    public async Task Test_GetHandlingByDateRange_When_CostService_Operation_Fails()
    {
        // arrange
        const string errorMessage = "costs service error!";
        var costsResult = new OperationResult<IEnumerable<CostDto>>(new ErrorResult(errorMessage));

        _costServiceMock.Setup(x => x.GetCosts())
            .ReturnsAsync(costsResult);

        // act
        var result = await _handlingServiceSut.GetHandlingByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>());
        
        // assert
        Assert.IsType<OperationResult<IEnumerable<HandlingDto>>>(result);
        Assert.NotNull(result);
        Assert.False(result.IsSuccessful);
        Assert.NotNull(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(errorMessage, result.Errors[0].Message);
    }
    
    [Fact]
    public async Task Test_GetHandlingByDateRange_When_Proxy_Operation_Fails()
    {
        // arrange
        const string errorMessage = "proxy error!";
        var costList = new List<CostDto>
        {
            new() { EmployeeType = "Vueling", FullTimeCost = 10.28m, PartTimeCost = 5.25m }
        };
        var costsResult = new OperationResult<IEnumerable<CostDto>>(costList);
        var handlingResult = new OperationResult<IEnumerable<HandlingDto>>(new ErrorResult(errorMessage));

        _costServiceMock.Setup(x => x.GetCosts())
            .ReturnsAsync(costsResult);
        
        _handlingProxyMock.Setup(x => x.GetHandlingByDay(It.IsAny<HandlingProxyRequest>()))
            .ReturnsAsync(handlingResult);
        
        // act
        var result = await _handlingServiceSut.GetHandlingByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>());
        
        // assert
        Assert.IsType<OperationResult<IEnumerable<HandlingDto>>>(result);
        Assert.NotNull(result);
        Assert.False(result.IsSuccessful);
        Assert.NotNull(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(errorMessage, result.Errors[0].Message);
    }
    
    [Fact]
    public async Task Test_GetHandlingByDateRange_When_Operation_Success()
    {
        // arrange
        var costList = new List<CostDto>
        {
            new() { EmployeeType = "Vueling", FullTimeCost = 10.28m, PartTimeCost = 5.25m }
        };
        var costsResult = new OperationResult<IEnumerable<CostDto>>(costList);

        var expectedData = new List<HandlingDto>
        {
            new() { HandlingFunction = "Yobal", FullTimeCost = 18.52m, PartTimeCost = 5, PartTimeEmployees = 3, FullTimeEmployees = 1, TotalCost = 52.37m, TotalEmployees = 4, Hour = 7, Day = DateTime.Now },
            new() { HandlingFunction = "TrianSixx", FullTimeCost = 6.52m, PartTimeCost = 9, PartTimeEmployees = 1, FullTimeEmployees = 5, TotalCost = 52.37m, TotalEmployees = 6, Hour = 9, Day = DateTime.Now }
        };
        var handlingResult = new OperationResult<IEnumerable<HandlingDto>>(expectedData);

        _costServiceMock.Setup(x => x.GetCosts())
            .ReturnsAsync(costsResult);
        
        _handlingProxyMock.Setup(x => x.GetHandlingByDay(It.IsAny<HandlingProxyRequest>()))
            .ReturnsAsync(handlingResult);
        
        // act
        var result = await _handlingServiceSut.GetHandlingByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>());
        
        // assert
        Assert.IsType<OperationResult<IEnumerable<HandlingDto>>>(result);
        Assert.NotNull(result);
        Assert.True(result.IsSuccessful);
        Assert.NotNull(result.Result);
        

        var resultList = result.Result.ToList();
        Assert.Equal(2, resultList.Count);
        
        var i = 0;
        foreach (var handlingDto in resultList)
        {
            Assert.Equal(expectedData[i].Day, handlingDto.Day);
            Assert.Equal(expectedData[i].Hour, handlingDto.Hour);
            Assert.Equal(expectedData[i].HandlingFunction, handlingDto.HandlingFunction);
            Assert.Equal(expectedData[i].FullTimeCost, handlingDto.FullTimeCost);
            Assert.Equal(expectedData[i].PartTimeCost, handlingDto.PartTimeCost);
            Assert.Equal(expectedData[i].TotalCost, handlingDto.TotalCost);
            Assert.Equal(expectedData[i].TotalEmployees, handlingDto.TotalEmployees);
            Assert.Equal(expectedData[i].FullTimeEmployees, handlingDto.FullTimeEmployees);
            Assert.Equal(expectedData[i].PartTimeEmployees, handlingDto.PartTimeEmployees);
            i++;
        }
    }
}