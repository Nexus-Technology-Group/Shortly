using Shortly.Analytics.Application;
using Shortly.Analytics.Application.DTOs;
using Shortly.Analytics.DAL.Abstractions.Requests;

namespace Shortly.Analytics.DAL.Abstractions;

public interface IRedirectStorage
{
    Task<RedirectMetricDTO> Create(StorageCreateRedirectMetricRequest request, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<RedirectMetricDTO>> GetByAuthorizationIdAndTime(Guid authorizationId,
        DateTime from, DateTime to, CancellationToken cancellationToken); // TODO Request
}