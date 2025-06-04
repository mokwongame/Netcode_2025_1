using Unity.Netcode;
using UnityEngine;

public class ExplosionNet : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("killExplosionRpc", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Rpc(SendTo.Server)]
    void killExplosionRpc()
    {
        NetworkObject.Despawn(); // Despawn()�� Spawn()�� �ݴ븻: ������ de�� ���شٴ� ��
    }
}
