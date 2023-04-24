using System.Net;
using System.Net.Sockets;

namespace Network;

/// <summary>
/// Contains information about this client's (local computer's) network
/// </summary>
public static class NetInfo
{
    /// <summary>
    /// The port to use for the client's server
    /// </summary>
    public const int Port = 49152;
    
    private static IPHostEntry? _hostEntry;
    /// <summary>
    /// The <see cref="IPHostEntry"/> for this client's network
    /// </summary>
    public static IPHostEntry HostEntry => _hostEntry ??= Dns.GetHostEntry(Dns.GetHostName());
    
    private static IPAddress? _localAddress;
    /// <summary>
    /// The <see cref="IPAddress"/> of this client
    /// </summary>
    public static IPAddress LocalAddress => _localAddress ??= HostEntry.AddressList[0];

    /// <summary>
    /// The <see cref="AddressFamily"/> of this client's connection
    /// </summary>
    public static AddressFamily AddressFamily => LocalAddress.AddressFamily;
    
    
    private static IPEndPoint? _localEndPoint;
    /// <summary>
    /// The <see cref="IPEndPoint"/> of this client's connection
    /// </summary>
    public static IPEndPoint LocalEndPoint => _localEndPoint ??= new IPEndPoint(LocalAddress, Port);
}