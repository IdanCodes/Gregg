namespace Communications.MessageLib; 

/// <summary>
/// A <see cref="MessageAttribute{T}"/> is used to represent a message attribute. 
/// </summary>
/// <typeparam name="T">The type for the <see cref="MessageAttribute{T}"/> to store.</typeparam>
public readonly struct MessageAttribute<T> where T : Encryptable {
    #region Properties
    
    /// <summary>
    /// The name of the <see cref="MessageAttribute{T}"/>.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The value of the <see cref="MessageAttribute{T}"/>.
    /// </summary>
    public readonly T? Value = default;
    
    #endregion
    
    #region Constructors
    
    /// <summary>
    /// Creates a new <see cref="MessageAttribute{T}"/> with the given value.
    /// </summary>
    /// <param name="name">What to call the <see cref="MessageAttribute{T}"/> when encrypting.</param>
    /// <param name="value">The value to initialize the <see cref="MessageAttribute{T}"/> with.</param>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="name"/> or <paramref name="value"/> are null.</exception>
    public MessageAttribute(string? name, T value) {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value ?? throw new ArgumentNullException(nameof(value));
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
    /// The start of an encrypted <see cref="MessageAttribute{T}"/>.
    /// </summary>
    public const string EncryptStart = "{";
    /// <summary>
    /// The end of an encrypted <see cref="MessageAttribute{T}"/>.
    /// </summary>
    public const string EncryptEnd = "}";
    /// <summary>
    /// The separator for the name and value of an encrypted <see cref="MessageAttribute{T}"/>.
    /// </summary>
    public const string EncryptSeparator = ",";

    /// <summary>
    /// Encrypts the <see cref="MessageAttribute{T}"/> into a string.
    /// </summary>
    /// <returns>The encrypted <see cref="MessageAttribute{T}"/></returns>
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
    /// Decrypts the given string into a <see cref="MessageAttribute{T}"/>.
    /// </summary>
    /// <param name="source">The source string to decrypt from</param>
    /// <returns>The decrypted <paramref name="source"/> as a <see cref="MessageAttribute{T}"/></returns>
    public static MessageAttribute<T> Decrypt(string source) {
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
        T value = Activator.CreateInstance<T>();
        value.Decrypt(valueString);
        
        return new MessageAttribute<T>(name, value);
    }
    
    #endregion
    
    #region Implicit Operators
    
    /// <summary>
    /// Implicitly converts the <see cref="MessageAttribute{T}"/> to its value.
    /// </summary>
    /// <param name="attribute">The attribute to convert</param>
    /// <returns>The <param name="attribute"></param>'s value</returns>
    /// <exception cref="ArgumentNullException">Thrown the when <param name="attribute">'s value is null</param></exception>
    public static implicit operator T(MessageAttribute<T> attribute) => attribute.Value ?? throw new ArgumentNullException(nameof(attribute.Value));
    
    #endregion
}