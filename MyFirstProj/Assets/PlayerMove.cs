using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // player 정보
    public float speed = 1.0f; // 한 프레임당 움직이는 유니티 유닛(unit)
    // 속도 = 거리/시간; 속도*시간 = 움직인 거리
    // 게임에서 사용하는 시간: Time.deltaTime(한 프레임을 그릴 때 필요한 시간)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 디버그 메시지 출력
        Debug.Log("PlayerMove start.");
    }

    // Update is called once per frame
    void Update()
    {
        float xoff = speed*Time.deltaTime;
        float zoff = speed * Time.deltaTime;
        // 현재 PlayerMove 스크립트를 실행하는 게임 오브젝트 GameObject의 인스턴스: gameObject
        // 실행된 gameObject의 실행된 Transform 인스턴스: transform
        // 원칙: gameObject.transform.Translate();
        // 간략화한 코드
        transform.Translate(xoff, 0.0f, zoff); // Translate(): Transform의 메소드(함수) -> 평행 이동하는 함수
    }
}
