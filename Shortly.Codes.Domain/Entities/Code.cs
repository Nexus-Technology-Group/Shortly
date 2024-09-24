using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.Domain.Entities;

public class Code
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public CodeType Type { get; init; }

    public string Value { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;
    
    public DateTime CreateDate { get; init; } = DateTime.UtcNow;
    
    public DateTime ExpiredDate { get; init; }
}