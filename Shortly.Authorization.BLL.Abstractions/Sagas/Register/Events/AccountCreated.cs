namespace Shortly.Authorization.BLL.Abstractions.Sagas.Register.Events;

public class AccountCreated
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}