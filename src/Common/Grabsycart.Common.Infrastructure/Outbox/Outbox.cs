namespace Grabsycart.Common.Infrastructure.Outbox;

public class Outbox
{
    public required Guid Id { get; set; }
    public required DateTime OccurredOnUtc { get; set; }      
    public required string Module { get; set; }   
    public required string Type { get; set; }      
    public required string Payload { get; set; } 
    public DateTime? ProcessedOnUtc { get; set; }
    public string? Error { get; set; }
}