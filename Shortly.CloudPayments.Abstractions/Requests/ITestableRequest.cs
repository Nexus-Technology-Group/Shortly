namespace Shortly.CloudPayments.Abstractions.Requests;

public interface ITestableRequest
{
    bool IsTest { get; init; }
}