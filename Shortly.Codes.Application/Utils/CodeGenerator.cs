namespace Shortly.Codes.Application.Utils;


public static class CodeGenerator
{
    private static readonly Random Random = new Random();
    private const int CODE_LENGTH = 6;
    
    public static string Generate()
    {
        var currentCode = string.Empty;
        for (var i = 0; i < CODE_LENGTH; i++)
        {
            currentCode += Random.Next(0, 9);
        }

        return currentCode;
    }
}