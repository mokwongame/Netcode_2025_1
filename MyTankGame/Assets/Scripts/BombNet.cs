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
        Invoke("killBombRpc", 4.0f); // 4초 뒤에 killBombRpc() 호출해서 포탄을 파괴
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

    [Rpc(SendTo.Server)] // Despawn()은 server RPC만 가능
    void killBombRpc()
    {
        NetworkObject.Despawn(); // Despawn()은 Spawn()의 반대말: 영어의 de는 없앤다는 뜻
    }
}
