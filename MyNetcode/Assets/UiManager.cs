using UnityEngine;
using TMPro;
using Unity.Netcode;

public class UiManager : MonoBehaviour
{
    public TMP_Text textNetState;

    private static UiManager _instance = null;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null) Debug.Log("UiManager is null.");
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
            Debug.Log("UiManager has another instance.");
            Destroy(gameObject);
        }
    }

    public void updateNetState()
    {
        string isServer = (NetworkManager.Singleton.IsServer) ? "O" : "X";
        string isClient = (NetworkManager.Singleton.IsClient) ? "O" : "X";
        string netState = $"server: {isServer}, client: {isClient}";
        textNetState.text = netState;
    }
}
