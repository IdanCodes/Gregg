namespace Communications.MessageLib; 

/// <summary>
/// A <see cref="MessageAttribute{T}"/> is used to represent a message attribute. 
/// </summary>
/// <typeparam name="T">The type for the <see cref="MessageAttribute{T}"/> to store.</typeparam>
public readonly struct MessageAttribute {
    #region Properties
    
    /// <summary>
    /// The name of the <see cref="MessageAttribute"/>.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The value of the <see cref="MessageAttribute"/>.
    /// </summary>
    public readonly object? Value = null;
    
    #endregion
    
    #region Constructors
    
    /// <summary>
    /// Creates a new <see cref="MessageAttribute"/> with the given value.
    /// </summary>
    /// <param name="name">What to call the <see cref="MessageAttribute"/> when encrypting.</param>
    /// <param name="value">The value to initialize the <see cref="MessageAttribute"/> with.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    public MessageAttribute(string? name, Encryptable value) {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value;
    }
    
    #endregion
    
    #region Encryption
    
    /*
     * Encryption method (Temporary):
     * Use '{}' to represent the start and end of an encrypted attribute.
     * Use ',' to separate the name and value of an encrypted attribute.
     * 
     * Format like this:
     *
     * {name,value}
     * 
     *  *name - The name of the attribute.
     *  *value - The value of the attribute.
     *
     * TODO: Change encryption method
     */
    
    /// <summary>
    /// The start of an encrypted <see cref="MessageAttribute"/>.
    /// </summary>
    public const string EncryptStart = "{";
    /// <summary>
    /// The end of an encrypted <see cref="MessageAttribute"/>.
    /// </summary>
    public const string EncryptEnd = "}";
    /// <summary>
    /// The separator for the name and value of an encrypted <see cref="MessageAttribute"/>.
    /// </summary>
    public const string EncryptSeparator = ",";

    /// <summary>
    /// Encrypts the <see cref="MessageAttribute"/> into a string.
    /// </summary>
    /// <returns>The encrypted <see cref="MessageAttribute"/></returns>
    /// <exception cref="ArgumentNullException">Thrown when the <see cref="Value"/> is null</exception>
    public string Encrypt() {
        // Check for null values
        if (Value == null)
            throw new ArgumentNullException(nameof(Value));
        if (Name == null)
            throw new ArgumentNullException(nameof(Name));
        
        string result = EncryptStart; // EncryptStart of attribute
        
        // Add name
        result += Name + EncryptSeparator;
        
        // Add value
        string value = Value.ToString() ?? throw new ArgumentNullException(nameof(Value));
        result += value;
        
        return result + EncryptEnd;
    }

    /// <summary>
    /// Decrypts the given string into a <see cref="MessageAttribute"/>.
    /// </summary>
    /// <param name="source">The source string to decrypt from</param>
    /// <returns>The decrypted <paramref name="source"/> as a <see cref="MessageAttribute"/></returns>
    public static MessageAttribute Decrypt(string source) {
        /*
         * source is gonna look like this:
         * {name,value}
         */
        
        // Remove start
        source = source.Remove(0, EncryptStart.Length);
        
        // Remove end
        source = source.Remove(source.Length - EncryptEnd.Length, EncryptEnd.Length);
        
        // Split into name and value
        string[] split = source.Split(EncryptSeparator);
        
        // Get name
        string name = split[0];
        
        // Get value
        string valueString = split[1];
        var value = Activator.CreateInstance<Encryptable>();
        value.Decrypt(valueString);
        
        return new MessageAttribute(name, value);
    }
    
    #endregion
}