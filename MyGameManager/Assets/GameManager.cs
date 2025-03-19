using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speed = 10.0f;

    // singleton pattern: 클래스 하나에 인스턴스가 하나만 생성되는 프래그래밍 패턴
    private static GameManager _instance = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this; // this: 현재 인스턴스를 가리키는 레퍼런스
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            // 현재 인스턴스 파괴
            Destroy(gameObject);
        }
    }
}
