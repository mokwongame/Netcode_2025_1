using UnityEngine;
using Unity.Netcode;
using System;

public class BulletNet : NetworkBehaviour
{
    Rigidbody rb;
    GameObject plane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!IsOwner) return; // owner 확인
        rb = GetComponent<Rigidbody>();
        plane = GameObject.Find("Plane");
        shotBulletRpc();
        Invoke("killBulletRpc", 3.0f);
    }

    [Rpc(SendTo.Owner)] // server RPC -> client RPC -> check owner
    private void shotBulletRpc() // AddForce는 owner만 호출 가능
    {
        rb.AddForce(plane.transform.forward * GameManager.Instance.BulletSpeed);
    }

    [Rpc(SendTo.Server)] // Despawn()은 server RPC만 가능
    void killBulletRpc()
    {
        NetworkObject.Despawn(); // Despawn()은 Spawn()의 반대말: 영어의 de는 없앤다는 뜻
    }

    // Update is called once per frame
    void Update()
    {

    }
}
