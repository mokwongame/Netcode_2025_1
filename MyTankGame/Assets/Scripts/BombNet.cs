using UnityEngine;
using Unity.Netcode;

public class BombNet : NetworkBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!IsOwner) return;
        rb = GetComponent<Rigidbody>();
        shotBombRpc();
        Invoke("killBombRpc", 4.0f); // 4�� �ڿ� killBombRpc() ȣ���ؼ� ��ź�� �ı�
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Rpc(SendTo.Owner)]
    void shotBombRpc()
    {
        rb.AddForce(transform.up * GameManager.Instance.ForceBomb);
    }

    [Rpc(SendTo.Server)] // Despawn()�� server RPC�� ����
    void killBombRpc()
    {
        NetworkObject.Despawn(); // Despawn()�� Spawn()�� �ݴ븻: ������ de�� ���شٴ� ��
    }
}
