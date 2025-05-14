using UnityEngine;
using Unity.Netcode;

public class PlayerHealthNet : NetworkBehaviour
{
    int maxHealth = 100;
    public NetworkVariable<int> health = new NetworkVariable<int>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        }
        base.OnNetworkSpawn();
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
}
