using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class BulletNB : NetworkBehaviour
{
    public float killTime = 3.0f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!IsOwner) return;
        rb = GetComponent<Rigidbody>();
        shotBulletRpc();
        Invoke("killBulletRpc", killTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Rpc(SendTo.Owner)]
    void shotBulletRpc()
    {
        rb.AddForce(Vector3.forward * GameManager.Instance.BulletForce);
    }

    [Rpc(SendTo.Server)]
    void killBulletRpc()
    {
        Debug.Log("ServerRpc");
        //GetComponent<NetworkObject>().Despawn();
        NetworkObject.Despawn();
    }
}
