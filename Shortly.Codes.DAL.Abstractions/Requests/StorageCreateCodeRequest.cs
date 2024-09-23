using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.DAL.Abstractions.Requests;

public sealed record StorageCreateCodeRequest(string Email, string Value, CodeType Type, DateTime ExpiredDate);