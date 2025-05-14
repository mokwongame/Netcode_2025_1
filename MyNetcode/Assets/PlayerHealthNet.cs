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

    // ��ũ��ũ�� �÷��̾ spawn�� �� ȣ��Ǵ� �̺�Ʈ ó����: OnNetworkSpawn()
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
    public void decHealthRpc() // Ȯ���ϰ� RPC�� NetworkVariable ����
    {
        decHealth();
    }
}
