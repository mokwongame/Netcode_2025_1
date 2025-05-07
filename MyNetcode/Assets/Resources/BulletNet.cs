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
        if (!IsOwner) return; // owner Ȯ��
        rb = GetComponent<Rigidbody>();
        plane = GameObject.Find("Plane");
        shotBulletRpc();
        Invoke("killBulletRpc", 3.0f);
    }

    [Rpc(SendTo.Owner)] // server RPC -> client RPC -> check owner
    private void shotBulletRpc() // AddForce�� owner�� ȣ�� ����
    {
        rb.AddForce(plane.transform.forward * GameManager.Instance.BulletSpeed);
    }

    [Rpc(SendTo.Server)] // Despawn()�� server RPC�� ����
    void killBulletRpc()
    {
        NetworkObject.Despawn(); // Despawn()�� Spawn()�� �ݴ븻: ������ de�� ���شٴ� ��
    }

    // Update is called once per frame
    void Update()
    {

    }
}
