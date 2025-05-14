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
        if (!IsOwner) return; // owner가 아니면 반환(return); 그래서 아래 코드는 owner만 실행함
        move();
        if (Input.GetKeyDown(KeyCode.Space))
            makeBulletRpc(); // Server RPC이기 때문에 owner만 이 함수 호출해야 함
    }

    [Rpc(SendTo.Server)] // Server RPC: Spawn() 때문에 server RPC만 가능
    private void makeBulletRpc()
    {
        // prefab 파일 불러오기(load): 이 파일은 Assets > Resources 폴더에 있어야 함
        GameObject prefabFile = Resources.Load("Bullet") as GameObject;
        // prefab의 예시 만들기(instantiate)
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position + plane.transform.forward * 2.0f + plane.transform.up * 2.0f; // transform은 플레이어의 변환
        prefab.transform.rotation = transform.rotation;
        prefab.GetComponent<NetworkObject>().Spawn(); // server RPC만 Spawn() 메소드 호출 가능
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

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Bullet")
        {
            Debug.Log("hit.");
        }
    }
}
