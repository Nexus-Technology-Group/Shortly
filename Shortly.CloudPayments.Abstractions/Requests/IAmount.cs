namespace Shortly.CloudPayments.Abstractions.Requests;

public interface IAmount
{
    decimal Amount { get; init; }
}