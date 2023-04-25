namespace Debugger;

/// <summary>
/// Logger - used to print messages to the console
/// </summary>
public static class Log {
    #region -- Color Constants --
    
    /// <summary>
    /// The default <see cref="ConsoleColor"/> to use when printing to the console
    /// </summary>
    public const ConsoleColor DefaultColor = ConsoleColor.White;
    
    /// <summary>
    /// The <see cref="ConsoleColor"/> to use when printing an info message to the console
    /// </summary>
    public const ConsoleColor InfoColor = ConsoleColor.Cyan;

    /// <summary>
    /// The <see cref="ConsoleColor"/> to use when printing an error message to the console
    /// </summary>
    public const ConsoleColor WarningColor = ConsoleColor.Yellow;

    /// <summary>
    /// The <see cref="ConsoleColor"/> to use when printing an error message to the console
    /// </summary>
    public const ConsoleColor ErrorColor = ConsoleColor.Red;
    
    #endregion
    
    #region -- String Constants --
    
    private const string NewLine = "\n";
    private const string Empty = "";
    
    #endregion

    #region -- Color Methods --
    
    /// <summary>
    /// Reset the console's color to <see cref="DefaultColor"/>.
    /// </summary>
    private static void ResetColor() => Console.ResetColor();
    
    /// <summary>
    /// Set the console's color to <paramref name="color"/>.
    /// </summary>
    /// <param name="color">The color to set the <see cref="Console"/>'s foreground color to</param>
    private static void SetColor(ConsoleColor color) {
        if (color == DefaultColor)
            ResetColor();
        else
            Console.ForegroundColor = color;
    }
    
    /// <summary>
    /// Sets the console's color to <paramref name="color"/>.
    /// If <paramref name="color"/> is <see langword="null"/>, the color will be reset to <see cref="DefaultColor"/>.
    /// </summary>
    /// <param name="color">The color to set the <see cref="Console"/>'s foreground color to</param>
    private static void SetColor(ConsoleColor? color) => SetColor(color ?? DefaultColor);

    #endregion

    #region -- Print Methods --

    /// <summary>
    /// Prints <paramref name="message"/> as a <see cref="string"/> to the console
    /// </summary>
    /// <param name="message">The message to print</param>
    /// <param name="color">The color to print the message in (Defaults to <see cref="DefaultColor"/>)</param>
    /// <param name="newLine">Start a new line after printing? (Defaults to <see langword="true"/>)</param>
    public static void Print(object message, ConsoleColor color = DefaultColor, bool newLine = true) {
        SetColor(color);
        Console.Write(message + (newLine ? NewLine : Empty));
        ResetColor();
    }
    
    /// <summary>
    /// Prints <paramref name="message"/> as a <see cref="string"/> to the console
    /// </summary>
    /// <param name="message">The message to print</param>
    /// <param name="color">The color to print the message in (Defaults to <see cref="DefaultColor"/>)</param>
    /// <param name="newLine">Start a new line after printing? (Defaults to <see langword="true"/>)</param>
    public static void Print(object message, ConsoleColor? color = null, bool newLine = true) => Print(message, color ?? DefaultColor, newLine);


    /// <summary>
    /// Prints an info message to the console
    /// </summary>
    /// <param name="message">The message to print</param>
    /// <param name="newLine">Print a new line after printing <paramref name="message"/>? (Defaults to true)</param>
    public static void Info(object message, bool newLine = true) => Print(message, InfoColor, newLine);
    

    /// <summary>
    /// Prints a warning message to the console
    /// </summary>
    /// <param name="message">The message to print</param>
    /// <param name="newLine">Print a new line after printing <paramref name="message"/>? (Defaults to true)</param>
    public static void Warning(object message, bool newLine = true) => Print(message, WarningColor, newLine);
    
    
    /// <summary>
    /// Prints an error message to the console
    /// <param name="message">The message to print</param>
    /// <param name="newLine">Print a new line after printing <paramref name="message"/>? (Defaults to true)</param>
    /// </summary>
    public static void Error(object message, bool newLine = true) => Print(message, ErrorColor, newLine);
    #endregion
}