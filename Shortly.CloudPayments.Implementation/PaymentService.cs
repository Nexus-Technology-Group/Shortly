using Shortly.CloudPayments.Abstractions;
using Shortly.CloudPayments.Abstractions.Http;
using Shortly.CloudPayments.Abstractions.Requests;

namespace Shortly.CloudPayments.Implementation;

public class PaymentService : IPaymentService
{
    private readonly IPaymentAPI _paymentAPI;
    
    public PaymentService(IPaymentAPI paymentAPI)
    {
        _paymentAPI = paymentAPI;
    }
    
    public async Task SendInvoice(SBPRequest request, CancellationToken cancellationToken)
    {
        var result = await _paymentAPI.Invoice(request, cancellationToken);
    }
}