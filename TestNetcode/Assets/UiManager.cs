using System.Data;
using Unity.Netcode;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Netcode.Transports.UTP;

public class UiManager : MonoBehaviour
{
    public TMP_Text textNumClients;
    public TMP_InputField inputIp;
    public TMP_InputField inputPort;

    private static UiManager _instance = null;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("UiManager is null.");
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (_instance == null) // 최초 실행
        {
            _instance = this;
        }
        else if (_instance != this) // 여러 번 실행
        {
            Debug.Log("UiManager has another instance.");
            Destroy(gameObject);
        }
    }

    public void startHost()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            updateConnectionData();
            NetworkManager.Singleton.StartHost();
        }
    }

    public void startServer()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            updateConnectionData();
            NetworkManager.Singleton.StartServer();
        }
    }

    public void startClient()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            updateConnectionData();
            NetworkManager.Singleton.StartClient();
        }
    }

    public int getNumClients()
    {
        System.Collections.Generic.IReadOnlyList<NetworkClient> connectedClients = NetworkManager.Singleton.ConnectedClientsList;
        return connectedClients.Count;
    }

    public void setConnectionData(string ipAddress, ushort port)
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipAddress, port);
    }

    public void updateNumClients()
    {
        int numClients = getNumClients();
        textNumClients.text = $"# of clients: {numClients}";
    }

    public void updateConnectionData()
    {
        string sIp = inputIp.text;
        if (string.IsNullOrEmpty(sIp))
        {
            sIp = "127.0.0.1";
        }
        string sPort = inputPort.text;
        if (string.IsNullOrEmpty(sPort))
        {
            sPort = "7777";
        }
        Debug.Log($"IP address = {sIp}, port # = {sPort}");
        ushort port = ushort.Parse(sPort); // 문자열 -> 다른 자료형: Parse()
        setConnectionData(sIp, port);
    }
}
