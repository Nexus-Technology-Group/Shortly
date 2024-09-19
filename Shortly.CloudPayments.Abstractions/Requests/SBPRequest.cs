namespace Shortly.CloudPayments.Abstractions.Requests;

public class SBPRequest : IPublicId, IAmount, ICurrency, IPayerEmail, IRedirectableRequest, ITestableRequest
{
    public string PublicId { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string SuccessRedirectUrl { get; init; } = string.Empty;
    public bool IsTest { get; init; }
}