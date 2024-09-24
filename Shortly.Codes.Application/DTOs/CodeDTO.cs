using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.Application.DTOs;

public class CodeDTO
{
    public Guid Id { get; init; }
    
    public CodeType Type { get; init; }
    
    public string Value { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;
    
    public DateTime CreateDate { get; init; } = DateTime.UtcNow;
    
    public DateTime ExpiredDate { get; init; }
}