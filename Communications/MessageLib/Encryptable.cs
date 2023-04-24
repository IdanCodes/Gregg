namespace Communications.MessageLib; 

/// <summary>
/// Used to represent encryptable attributes of <see cref="MessageAttribute{T}"/> that can be sent between <see cref="ComSocket"/>s.
/// </summary>
public abstract class Encryptable {
    /// <summary>
    /// Creates a new <see cref="Encryptable"/>.
    /// </summary>
    protected Encryptable() { }

    /// <summary>
    /// Encrypts the <see cref="Encryptable"/> into a string.
    /// </summary>
    /// <returns>The encrypted value</returns>
    /// <exception cref="ArgumentNullException">Thrown if this.ToString() returns a null value</exception>
    public virtual string Encrypt() {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Decrypts the <see cref="Encryptable"/> from a string. 
    /// </summary>
    /// <param name="source">The source to decrypt from</param>
    public virtual void Decrypt(string source) {
        throw new NotImplementedException();
    }
}
