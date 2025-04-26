using UnityEngine;
using Unity.Netcode;

public class MovePlayerNet : NetworkBehaviour
{
    GameObject plane;

    //public float speed = 10.0f; // 초당 10 유닛 움직이는 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return; // 소유자(owner)가 아니라면 Update()하지 않음
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

    // []: 속성(attribute)
    [Rpc(SendTo.Server)] // RPC를 쓰는 함수 이름은 Rpc로 끝나야 함
    void makeBulletRpc()
    {
        // Standalone: Prefab으로 초기화한 GameObject -> Instantiate()
        // Network: Prefab 파일 읽기 -> GameObject인 Prefab을 Instantiate()으로 생성
        GameObject prefabFile = Resources.Load("Bullet") as GameObject; // 파일은 Assets > Resources 폴더에 저장되어야 됨
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position + plane.transform.forward * 1.0f + plane.transform.up * 2.0f;
        prefab.transform.rotation = transform.rotation;
        // Spawn() 함수로 인해 makeBullet()의 실행은 서버에서만 해야 됨: RPC (remote procedure call); procedure는 함수; 원격 함수 호출
        prefab.GetComponent<NetworkObject>().Spawn(); // 개구리의 알 -> 알 낳기
    }
}
