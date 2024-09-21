using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.Application.DTOs;

public class CodeDTO
{
    public Guid Id { get; init; }
    
    public Guid AuthorizationId { get; init; }
    
    public CodeType Type { get; init; }
    
    public string Value { get; init; }
    
    public string Email { get; init; }
    
    public DateTime CreateDate { get; init; } = DateTime.UtcNow;
    
    public DateTime ExpiredDate { get; init; }
}