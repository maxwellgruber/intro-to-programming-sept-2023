namespace Banking.Api.Models;

//{"id": "89898", "name": "Bob Smith" }

public record AccountSummaryResponse
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}


public record AccountCreateRequest
{
    public string Name { get; set; } = string.Empty;
}