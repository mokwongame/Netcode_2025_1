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

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ��ġ�� BombRed(tag = Bomb)
        string tag = collision.gameObject.tag; // �浹�� ���ü�� tag
        if (tag == "Plane") // ���� �ε���
        {
            makeExplosionRpc();
            killBombRpc();
        }
        else if (tag == "Player") // ���� ��ũ�� �浹
        {
            makeExplosionRpc();
            killBombRpc();
        }
    }

    [Rpc(SendTo.Server)]
    void makeExplosionRpc()
    {
        GameObject prefabFile = Resources.Load("ExplosionRed") as GameObject;
        // prefab�� ���� �����(instantiate)
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position;
        prefab.transform.rotation = transform.rotation;
        prefab.GetComponent<NetworkObject>().Spawn(); // server RPC�� Spawn() �޼ҵ� ȣ�� ����
    }
}
