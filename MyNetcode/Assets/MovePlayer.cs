using UnityEngine;
using Unity.Netcode;
using UnityEngine.EventSystems;
using System;

public class MovePlayer : NetworkBehaviour
{
    //public GameObject plane; // Plane은 게임 오브젝트라서 프리팹에서는 접근 불가
    GameObject plane; // Plane과 Playe가 게임 오브젝트로 생성된 후에 접근

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

        // 1. 가장 기본적인 방법: 지역 좌표계에서 이동
        //transform.Translate(xoff, 0.0f, zoff);

        // 2. transform의 좌표축 사용: right(+x), up(+y), forward(+z)
        //Vector3 pos = transform.position;
        //pos += transform.right * xoff + transform.forward * zoff;
        //transform.position = pos;

        // 3. 외부의 고정된 좌표축(Plane의 좌표축) 사용
        Vector3 pos = transform.position;
        pos += plane.transform.right * xoff + plane.transform.forward * zoff;
        transform.position = pos;
    }
}
