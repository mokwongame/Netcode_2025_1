using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerHealthNet : NetworkBehaviour
{
    int maxHealth = 100;
    public NetworkVariable<int> health = new NetworkVariable<int>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public NetworkVariable<FixedString128Bytes> userId = new NetworkVariable<FixedString128Bytes>("player", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    TMP_Text textHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textHealth = GameObject.Find("TextHealth").GetComponent<TMP_Text>();
        textHealth.text = $"health = {maxHealth}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 네크워크에 플레이어가 spawn될 때 호출되는 이벤트 처리기: OnNetworkSpawn()
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            health.Value = maxHealth; // write
            health.OnValueChanged += OnHealthChanged;
            userId.Value = GameManager.Instance.UserId;
        }
        base.OnNetworkSpawn();
    }

    void OnHealthChanged(int prevValue, int newValue)
    {
        // newValue가 health.Value가 됨
        textHealth.text = $"health = {newValue}";
    }

    public void decHealth()
    {
        int curValue = health.Value - 1;
        if (curValue < 0) curValue = 0;
        health.Value = curValue;
        Debug.Log($"health = {health.Value}");
    }

    [Rpc(SendTo.Owner)]
    public void decHealthRpc() // 확실하게 RPC로 NetworkVariable 갱신
    {
        decHealth();
    }

    private void OnGUI() // GUI를 처리하는 이벤트 처리기
    {
        Vector3 offset = new Vector3(-1.0f, 2.0f, 0.0f);
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position + offset);
        Rect rect = new Rect(0, 0, 100, 50);
        rect.x = pos.x;
        rect.y = Screen.height - pos.y;
        string text = $"{userId.Value}: {health.Value}";
        GUI.Label(rect, text);
    }
}
