namespace Shortly.Codes.Application;

public class CodesOptions
{
    #region CodesTTL

    public int AbsoluteCodeTTLInMinutes { get; set; }
    public int ConfirmationTTLInMinutes { get; set; }
    public int PasswordRecoveryTTLInMinutes { get; set; }

    #endregion
}