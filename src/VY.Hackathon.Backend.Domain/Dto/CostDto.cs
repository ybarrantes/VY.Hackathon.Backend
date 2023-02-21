namespace VY.Hackathon.Backend.Domain.Dto;

public record CostDto
{
    public DateTime? Day { get; set; }
    public string EmployeeType { get; set; }
    public decimal FullTimeCost { get; set; }
    public decimal PartTimeCost { get; set; }
}