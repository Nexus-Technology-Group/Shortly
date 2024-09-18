namespace Shortly.Link.Application.Generator;

/// <summary>
/// Провайдер, занимающийся нахождением нужных строк с символами
/// </summary>
internal static class SymbolProvider
{
    private const string NUMBERS = "0123456789";
    private const string LOWER_CASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";
    private const string UPPER_CASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SPECIAL_SYMBOLS = "!#$%&*@";

    private static readonly Dictionary<PresentedSymbols, string?> SymbolDictionary =
        new()
        {
            { PresentedSymbols.Numbers, NUMBERS },
            { PresentedSymbols.LowerCase, LOWER_CASE_LETTERS },
            { PresentedSymbols.LowerAndUpperCases, LOWER_CASE_LETTERS + UPPER_CASE_LETTERS },
            { PresentedSymbols.LowerUpperCasesAndNumbers, NUMBERS + LOWER_CASE_LETTERS + UPPER_CASE_LETTERS },
            {
                PresentedSymbols.LowerUpperCasesNumbersAndSpecialSymbols,
                NUMBERS + LOWER_CASE_LETTERS + UPPER_CASE_LETTERS + SPECIAL_SYMBOLS
            }
        };

    /// <summary>
    /// Метод, который создает строку, из которой в дальнейшем будет генерироваться случайная строка.
    /// </summary>
    /// <param name="presentedSymbols"></param>
    public static string? MakeSymbolString(PresentedSymbols presentedSymbols)
    {
        SymbolDictionary.TryGetValue(presentedSymbols, out var result);
        return result;
    }
}