using UnityEngine;
using Unity.Netcode;

public class MovePlayerNet : NetworkBehaviour
{
    //public float speed = 10.0f; // �ʴ� 10 ���� �����̴� �ӵ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return; // ������(owner)�� �ƴ϶�� Update()���� ����
        move();
    }

    private void move()
    {
        float xoff = Input.GetAxis("Horizontal") * GameManager.Speed * Time.deltaTime;
        float zoff = Input.GetAxis("Vertical") * GameManager.Speed * Time.deltaTime;
        NetworkObject.transform.Translate(xoff, 0.0f, zoff);
    }
}
