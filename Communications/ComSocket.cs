using System.Net;
using System.Net.Sockets;
using Network;

namespace Communications;

/// <summary>
/// The <see cref="ComSocket"/> class is used to represent a communication socket.
/// <see cref="ComSocket"/>s can communicate between them using their built in methods.
/// </summary>
public abstract class ComSocket : Socket {
    #region Properties

    public IPEndPoint LocalEndpoint => NetInfo.LocalEndPoint;

    #endregion
    
    #region Delegates
    
    public delegate void ComSocketEvent(ComSocket server);
    
    #endregion
    
    #region -- Events --
    
    public event ComSocketEvent? OnConnected;
    public event ComSocketEvent? OnReceivedConnection;
    public event ComSocketEvent? OnDisconnected;
    public event ComSocketEvent? OnReceivedDisconnection;

    #endregion
    
    #region Constructors
    
    protected ComSocket() :
            base(NetInfo.AddressFamily, SocketType.Stream, ProtocolType.Tcp) { }
    
    #endregion
    
    #region Connection
    
    private void Connect(IPEndPoint? endPoint) {
        if (endPoint == null)
            throw new ArgumentNullException(nameof(endPoint));
        
        // TODO: Connect to socket and request its ComSocket data
        base.Connect(endPoint);
    }
    
    public void Connect(ComSocket comSocket) {
        if (comSocket.LocalEndPoint == null)
            throw new ArgumentNullException(nameof(comSocket.LocalEndPoint));
        
        Connect(comSocket.LocalEndPoint);
    }
    
    #endregion
    
    #region ComSocket Communications

    // TODO: Implement Messages
    
    #endregion
}
