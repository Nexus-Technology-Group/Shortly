namespace Shortly.Link.Application.Generator;

/// <summary>
/// Генератор случайных строк
/// </summary>
public static class RandomStringGenerator
{
    /// <summary>
    /// Метод, позволящий создать случайную строку исходя из настроек
    /// </summary>
    /// <param name="length">Длина желаемой строки</param>
    /// <param name="presentedSymbols">Символы, которые необходимо включить</param>
    /// <returns>Возвращает сгенирированную случайную строку</returns>
    /// <exception cref="ArgumentException">Возникает, если указанная длина менее или равна 1 символу</exception>
    public static string GenerateRandomString(int length = 12, PresentedSymbols presentedSymbols = PresentedSymbols.LowerUpperCasesNumbersAndSpecialSymbols)
    {
        if (length <= 1)
            throw new ArgumentException("Некорректная длина генерируемой строки", nameof(length));

        var usingSymbols = SymbolProvider.MakeSymbolString(presentedSymbols);

        if (usingSymbols == null)
            throw new ArgumentException("Некорректная source строка, содержащая символы для генерации", usingSymbols);

        var usingSymbolsLength = usingSymbols.Length;
        var result = string.Empty;

        for (var i = 0; i < length; i++)
        {
            var index = Random.Shared.Next(0, usingSymbolsLength);
            result += usingSymbols[index];
        }

        return result;
    }
}

/// <summary>
/// Используемые символы
/// </summary>
public enum PresentedSymbols
{
    /// <summary>
    /// Только цифры
    /// </summary>
    Numbers = 0,

    /// <summary>
    /// Только буквы нижнего регистра
    /// </summary>
    LowerCase = 1,

    /// <summary>
    /// Буквы нижнего и верхнего регистра
    /// </summary>
    LowerAndUpperCases = 2,

    /// <summary>
    /// Буквы нижнего, верхнего регистра и цифры
    /// </summary>
    LowerUpperCasesAndNumbers = 3,

    /// <summary>
    /// Буквы нижнего, верхнего регистра, цифры и спец. символы
    /// </summary>
    LowerUpperCasesNumbersAndSpecialSymbols = 4
}