using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.DAL.Abstractions.Requests;

public sealed record StorageGetCodeByTypeRequest(string Email, CodeType Type);