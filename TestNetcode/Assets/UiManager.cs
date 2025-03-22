using System.Data;
using Unity.Netcode;
using UnityEngine;

public class UiManager : MonoBehaviour
{
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
            NetworkManager.Singleton.StartHost();
    }

    public void startServer()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
            NetworkManager.Singleton.StartServer();
    }

    public void startClient()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
            NetworkManager.Singleton.StartClient();
    }
}
