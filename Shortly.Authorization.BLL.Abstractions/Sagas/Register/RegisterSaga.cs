using System.Runtime.Intrinsics.X86;
using MassTransit;
using MassTransit.Mediator;
using Shortly.Authorization.BLL.Abstractions.Sagas.Register.Events;

namespace Shortly.Authorization.BLL.Abstractions.Sagas.Register;

public class RegisterSaga : MassTransitStateMachine<RegisterState>
{
    public Event<RegisterRequested> RegisterRequested { get; private set; }
    public Event<CodeCreated> CodeSubmitted { get; private set; }
    public State CodeCreatedState { get; private set; }

    public Request<RegisterState, ValidateLoginRequest, LoginValidResponse, LoginInvalidResponse> ValidateLoginRequest
    {
        get;
        private set;
    } = null!;

    public Request<RegisterState, CreateCodeRequest, CodeCreated, CodeNotCreated> CreateCodeRequest
    {
        get;
        private set;
    } = null!;

    public Request<RegisterState, ValidateCodeRequest, CodeValidResponse, CodeInvalidResponse> ValidateCodeRequest
    {
        get;
        private set;
    } = null!;

    public Request<RegisterState, CreateAccountRequest, AccountCreatedResponse, AccountNotCreatedResponse>
        CreateAccountRequest
    {
        get;
        private set;
    } = null!;

    public RegisterSaga()
    {
        InstanceState(x => x.CurrentState);

        // Получение запроса RequestReceived
        // Проверка на существование такой почты RequestAccepted
        // Отправка письма на почту CodeSubmitted
        // Получение кода из письма CodeAccepted
        // Валидация кода CodeValidated
        // Создание авторизации и входа AccountCreated

        Event(() => RegisterRequested, x => x.CorrelateBy(state => state.Login, context => context.Message.Login)
            .SelectId(_ => Guid.NewGuid()));

        Initially(
            When(RegisterRequested)
                .Then(context =>
                {
                    context.Saga.Login = context.Message.Login;
                    context.Saga.Password = context.Message.Password;
                })
                .Request(ValidateLoginRequest, x => new ValidateLoginRequest(x.Saga.CorrelationId, x.Saga.Login))
                .TransitionTo(ValidateLoginRequest.Pending),
            
            When(CodeSubmitted)
                .Then(x => x.Saga.Code = x.Message.Value)
                .Request(ValidateCodeRequest, x => new ValidateCodeRequest(x.Saga.CorrelationId, x.Saga.Login, x.Saga.Code))
                .TransitionTo(ValidateCodeRequest.Pending)
        );

        During(ValidateLoginRequest.Pending, When(ValidateLoginRequest.Completed)
            .Request(CreateCodeRequest, x => new CreateCodeRequest(x.Saga.CorrelationId, x.Saga.Login))
            .TransitionTo(CreateCodeRequest.Pending));

        During(CreateCodeRequest.Pending, When(CreateCodeRequest.Completed)
            .TransitionTo(CodeCreatedState));
        
        During(ValidateCodeRequest.Pending, When(ValidateCodeRequest.Completed)
            .Request(CreateAccountRequest, x => new CreateAccountRequest(x.Saga.CorrelationId, x.Saga.Login, x.Saga.Password))
            .TransitionTo(CreateCodeRequest.Pending));
        
        During(CreateAccountRequest.Pending, When(CreateAccountRequest.Completed)
            .Then(x =>
            {
                x.Saga.AccessToken = x.Message.AccessToken;
                x.Saga.RefreshTokne = x.Message.RefreshToken;
            })
            .Finalize());

        SetCompletedWhenFinalized();
    }
}

public record ValidateLoginRequest(Guid CorrelationId, string Login);

public record LoginValidResponse(Guid CorrelationId);

public record LoginInvalidResponse(Guid CorrelationId);

public record CreateCodeRequest(Guid CorrelationId, string Login);

public record CodeCreated(Guid CorrelationId, string Value);

public record CodeNotCreated(Guid CorrelationId);

public record ValidateCodeRequest(Guid CorrelationId, string Login, string Code);

public record CodeValidResponse(Guid CorrelationId);

public record CodeInvalidResponse(Guid CorrelationId);

public record CreateAccountRequest(Guid CorrelationId, string Login, string Password);

public record AccountCreatedResponse(Guid CorrelationId, string AccessToken, string RefreshToken);

public record AccountNotCreatedResponse(Guid CorrelationId);