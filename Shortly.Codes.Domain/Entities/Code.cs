using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.Domain.Entities;

public class Code
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public CodeType Type { get; init; }
    
    public string Value { get; init; }
    
    public string Email { get; init; }
    
    public DateTime CreateDate { get; init; } = DateTime.UtcNow;
    
    public DateTime ExpiredDate { get; init; }
}