using Shortly.Codes.Application.DTOs;
using Shortly.Codes.Domain.Entities;

namespace Shortly.Codes.DAL.Mongo.Utils;

public static class CodeMapper
{
    public static CodeDTO Map(this Code entity)
    {
        return new CodeDTO()
        {
            Id = entity.Id,
            Type = entity.Type,
            Value = entity.Value,
            Email = entity.Email,
            CreateDate = entity.CreateDate,
            ExpiredDate = entity.ExpiredDate
        };
    }
}