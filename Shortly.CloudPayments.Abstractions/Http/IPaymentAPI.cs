using Refit;
using Shortly.CloudPayments.Abstractions.Requests;

namespace Shortly.CloudPayments.Abstractions.Http;

public interface IPaymentAPI
{
    [Post("payments/qr/sbp/link")]
    Task<HttpResponseMessage> Invoice([Body] SBPRequest request, CancellationToken cancellationToken);
}