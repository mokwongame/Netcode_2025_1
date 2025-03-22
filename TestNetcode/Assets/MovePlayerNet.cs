using UnityEngine;
using Unity.Netcode;

public class MovePlayerNet : NetworkBehaviour
{
    //public float speed = 10.0f; // 초당 10 유닛 움직이는 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return; // 소유자(owner)가 아니라면 Update()하지 않음
        move();
    }

    private void move()
    {
        float xoff = Input.GetAxis("Horizontal") * GameManager.Speed * Time.deltaTime;
        float zoff = Input.GetAxis("Vertical") * GameManager.Speed * Time.deltaTime;
        NetworkObject.transform.Translate(xoff, 0.0f, zoff);
    }
}
