using UnityEngine;
using Unity.Netcode;

public class MovePlayerNet : NetworkBehaviour
{
    GameObject plane;

    //public float speed = 10.0f; // �ʴ� 10 ���� �����̴� �ӵ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return; // ������(owner)�� �ƴ϶�� Update()���� ����
        move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            makeBulletRpc();
        }
    }

    private void move()
    {
        float xoff = Input.GetAxis("Horizontal") * GameManager.Speed * Time.deltaTime;
        float zoff = Input.GetAxis("Vertical") * GameManager.Speed * Time.deltaTime;
        //transform.Translate(xoff, 0.0f, zoff);

        Vector3 pos = transform.position;
        pos += plane.transform.right * xoff + plane.transform.forward * zoff;
        transform.position = pos;
    }

    // []: �Ӽ�(attribute)
    [Rpc(SendTo.Server)] // RPC�� ���� �Լ� �̸��� Rpc�� ������ ��
    void makeBulletRpc()
    {
        // Standalone: Prefab���� �ʱ�ȭ�� GameObject -> Instantiate()
        // Network: Prefab ���� �б� -> GameObject�� Prefab�� Instantiate()���� ����
        GameObject prefabFile = Resources.Load("Bullet") as GameObject; // ������ Assets > Resources ������ ����Ǿ�� ��
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position + plane.transform.forward * 1.0f + plane.transform.up * 2.0f;
        prefab.transform.rotation = transform.rotation;
        // Spawn() �Լ��� ���� makeBullet()�� ������ ���������� �ؾ� ��: RPC (remote procedure call); procedure�� �Լ�; ���� �Լ� ȣ��
        prefab.GetComponent<NetworkObject>().Spawn(); // �������� �� -> �� ����
    }
}
