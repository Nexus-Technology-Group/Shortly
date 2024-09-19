namespace Shortly.CloudPayments.Abstractions.Requests;

public interface IRedirectableRequest
{
    string SuccessRedirectUrl { get; init; }
}