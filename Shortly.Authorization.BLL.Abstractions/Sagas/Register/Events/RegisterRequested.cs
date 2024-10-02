namespace Shortly.Authorization.BLL.Abstractions.Sagas.Register.Events;

public class RegisterRequested
{
    public string Login { get; set; }
    public string Password { get; set; }
}