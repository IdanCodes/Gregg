namespace Communications.MessageLib; 

// TODO: Message encryption
// TODO: Message comparison
// TODO: Communications between ComSockets
// TODO: Client and server stuff

/// <summary>
/// Used to represent messages that can be sent between <see cref="ComSocket"/>s.
/// </summary>
public class Message {
    private List<MessageAttribute<Encryptable>> _attributes;
    
    #region Constructors

    public Message(MessageAttribute<Encryptable>[]? attributes = null) {
        _attributes = (attributes ?? Array.Empty<MessageAttribute<Encryptable>>()).ToList();
    }
    
    #endregion
    
    #region Attribute Management
    
    // -- AddAttribute -- //
    
    /// <summary>
    /// Adds the given <see cref="MessageAttribute{T}"/> to the <see cref="Message"/>.
    /// </summary>
    /// <param name="attribute">The attribute to add</param>
    /// <returns>Has the attribute successfully been added</returns>
    public bool AddAttribute(MessageAttribute<Encryptable> attribute) {
        if (HasAttribute(attribute)) return false;
        
        _attributes.Add(attribute);
        return true;
    }
    
    
    // -- RemoveAttribute -- //
    
    /// <summary>
    /// Removes the given <see cref="MessageAttribute{T}"/> from the <see cref="Message"/>.
    /// </summary>
    /// <param name="attribute">The attribute to remove</param>
    /// <returns>Has the attribute been removed successfully</returns>
    public bool RemoveAttribute(MessageAttribute<Encryptable> attribute) => _attributes.Remove(attribute);
    
    
    // -- HasAttribute -- //
    
    /// <summary>
    /// Does the <see cref="Message"/> have the given <see cref="MessageAttribute{T}"/>.
    /// </summary>
    /// <param name="attribute">The attribute to check</param>
    /// <returns>If the <see cref="Message"/> has the attribute</returns>
    public bool HasAttribute(MessageAttribute<Encryptable> attribute) => _attributes.Any(attr => attr == attribute);
    /// <summary>
    /// Does the <see cref="Message"/> have the given <see cref="MessageAttribute{T}"/> with the given name.
    /// </summary>
    /// <param name="name">The name to match to the attribute</param>
    /// <returns>If the <see cref="Message"/> has the attribute</returns>
    public bool HasAttribute(string name) => _attributes.Any(attr => attr.Name == name);

    
    // -- GetAttribute -- //
    
    /// <summary>
    /// Gets the <see cref="MessageAttribute{T}"/> with the given name.
    /// </summary>
    /// <param name="attribute">The attribute to fetch</param>
    /// <returns>True, if the <see cref="MessageAttribute{T}"/> exists inside the <see cref="Message"/>, otherwise return false.</returns>
    public MessageAttribute<Encryptable>? GetAttribute(MessageAttribute<Encryptable> attribute) => _attributes.FirstOrDefault(attr => attr == attribute);
    /// <summary>
    /// Gets the <see cref="MessageAttribute{T}"/> with the given name.
    /// </summary>
    /// <param name="name">The name of the <see cref="MessageAttribute{T}"/> to check</param>
    /// <returns>True, if the <see cref="MessageAttribute{T}"/> with <paramref name="name"/> exists inside the <see cref="Message"/>, otherwise return false.</returns>
    public MessageAttribute<Encryptable>? GetAttribute(string name) => _attributes.FirstOrDefault(attr => attr.Name == name);

    
    // -- TryGetAttribute -- //
    
    /// <summary>
    /// Tries to get the <see cref="MessageAttribute{T}"/> that matches the given attribute
    /// </summary>
    /// <param name="attribute">The <see cref="MessageAttribute{T}"/> to match to</param>
    /// <param name="result">The <see cref="MessageAttribute{T}"/> from the attributes list</param>
    /// <returns>Was the attribute found?</returns>
    public bool TryGetAttribute(MessageAttribute<Encryptable> attribute, out MessageAttribute<Encryptable> result) {
        MessageAttribute<Encryptable>? temp = GetAttribute(attribute);
        result = temp ?? default;
        return temp != null;
    }
    /// <summary>
    /// Tries to get the <see cref="MessageAttribute{T}"/> that matches the given name
    /// </summary>
    /// <param name="name">The name to match to</param>
    /// <param name="attribute">The <see cref="MessageAttribute{T}"/> from the attributes list</param>
    /// <returns>Was the attribute found?</returns>
    public bool TryGetAttribute(string name, out MessageAttribute<Encryptable> attribute) {
        MessageAttribute<Encryptable>? temp = GetAttribute(name);
        attribute = temp ?? default;
        return temp != null;
    }

    #endregion
    
}