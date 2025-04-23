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
        if (!IsOwner) return;
        move();
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
}
