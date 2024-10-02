using MassTransit;

namespace Shortly.Authorization.BLL.Abstractions.Sagas.Register;

public class RegisterState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    public string Code { get; set; }
    public string AccessToken { get; set; }
    public string RefreshTokne { get; set; }
}