using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum NodeType
    { NULL = 0, HOST, CLIENT, SERVER }

    public NodeType UserNodeType
    { get; set; }

    public string UserId
    { get; set; }

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initParam();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void initParam()
    {
        UserNodeType = NodeType.NULL;
    }

    public int getNumClients()
    {
        if (NetworkManager.Singleton == null) return 0;
        System.Collections.Generic.IReadOnlyList<NetworkClient> connectedClients = NetworkManager.Singleton.ConnectedClientsList;
        return connectedClients.Count;
    }

    public void setConnection(string ipAddress, ushort portNum)
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipAddress, portNum);
    }

    public void startHost()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Host started.");
            NetworkManager.Singleton.StartHost();
        }
    }

    public void startServer()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Server started.");
            NetworkManager.Singleton.StartServer();
        }
    }

    public void startClient()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Client started.");
            NetworkManager.Singleton.StartClient();
        }
    }

    public void startNode()
    {
        if (UserNodeType == NodeType.HOST)
            startHost();
        else if (UserNodeType == NodeType.CLIENT)
            startClient();
        else if (UserNodeType == NodeType.SERVER)
            startServer();
        else
        {
            Debug.Log("Unknown node type.");
        }
    }
}
