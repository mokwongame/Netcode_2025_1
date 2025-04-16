using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public void startHost()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Host started.");
            NetworkManager.Singleton.StartHost();
            UiManager.Instance.updateNetState();
        }
    }

    public void startServer()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Server started.");
            NetworkManager.Singleton.StartServer();
            UiManager.Instance.updateNetState();
        }
    }

    public void startClient()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Client started.");
            NetworkManager.Singleton.StartClient();
            UiManager.Instance.updateNetState();
        }
    }
}
