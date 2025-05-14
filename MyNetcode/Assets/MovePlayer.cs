using UnityEngine;
using Unity.Netcode;
using UnityEngine.EventSystems;
using System;

public class MovePlayer : NetworkBehaviour
{
    //public GameObject plane; // Plane�� ���� ������Ʈ�� �����տ����� ���� �Ұ�
    GameObject plane; // Plane�� Playe�� ���� ������Ʈ�� ������ �Ŀ� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return; // owner�� �ƴϸ� ��ȯ(return); �׷��� �Ʒ� �ڵ�� owner�� ������
        move();
        if (Input.GetKeyDown(KeyCode.Space))
            makeBulletRpc(); // Server RPC�̱� ������ owner�� �� �Լ� ȣ���ؾ� ��
    }

    [Rpc(SendTo.Server)] // Server RPC: Spawn() ������ server RPC�� ����
    private void makeBulletRpc()
    {
        // prefab ���� �ҷ�����(load): �� ������ Assets > Resources ������ �־�� ��
        GameObject prefabFile = Resources.Load("Bullet") as GameObject;
        // prefab�� ���� �����(instantiate)
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position + plane.transform.forward * 2.0f + plane.transform.up * 2.0f; // transform�� �÷��̾��� ��ȯ
        prefab.transform.rotation = transform.rotation;
        prefab.GetComponent<NetworkObject>().Spawn(); // server RPC�� Spawn() �޼ҵ� ȣ�� ����
    }

    private void move()
    {
        float speed = GameManager.Instance.Speed;
        float xoff = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zoff = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // 1. ���� �⺻���� ���: ���� ��ǥ�迡�� �̵�
        //transform.Translate(xoff, 0.0f, zoff);

        // 2. transform�� ��ǥ�� ���: right(+x), up(+y), forward(+z)
        //Vector3 pos = transform.position;
        //pos += transform.right * xoff + transform.forward * zoff;
        //transform.position = pos;

        // 3. �ܺ��� ������ ��ǥ��(Plane�� ��ǥ��) ���
        Vector3 pos = transform.position;
        pos += plane.transform.right * xoff + plane.transform.forward * zoff;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Bullet")
        {
            Debug.Log("hit.");
        }
    }
}
