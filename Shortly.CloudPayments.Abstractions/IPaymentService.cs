using Shortly.CloudPayments.Abstractions.Requests;

namespace Shortly.CloudPayments.Abstractions;

public interface IPaymentService
{
    Task SendInvoice(SBPRequest request, CancellationToken cancellationToken);
}