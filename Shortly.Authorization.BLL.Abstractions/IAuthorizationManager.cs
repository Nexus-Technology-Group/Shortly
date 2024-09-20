﻿using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.BLL.Abstractions.Requests;

namespace Shortly.Authorization.BLL.Abstractions;

public interface IAuthorizationManager
{
    Task<AuthorizationDTO> Create(ManagerCreateAuthorizationRequest request, CancellationToken cancellationToken);
}