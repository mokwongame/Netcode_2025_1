using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public float speed = 10.0f; // 필드; public하면 객체 지향의 철학과 동떨어짐
    public float Speed // 프로퍼티
    { get; set; }
    public float SpeedStep
    { get; set; }

    // singleton pattern: 클래스 하나에 인스턴스가 하나만 생성되는 프래그래밍 패턴
    private static GameManager _instance = null; // 멤버 변수 선언, 정의 = 필드(field) 선언 ->  외부 접근 불가(private, protected 선언)
    public static GameManager Instance // 변수 + 함수 = 필드 + 메소드 = 프로퍼티(property) -> 외부 접근을 수월하게(public 선언), 외부에서는 변수처럼 사용
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initParam();
        UiManager.Instance.showSpeed();
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
        // 씬이 바뀌어도 현재 게임 오브젝트를 유지
        DontDestroyOnLoad(gameObject);
    }

    void initParam()
    {
        Speed = 10.0f;
        SpeedStep = 1.0f;
    }

    public void incSpeed()
    {
        Speed += SpeedStep;
        UiManager.Instance.showSpeed();
    }

    public void decSpeed()
    {
        Speed -= SpeedStep;
        if (Speed < 0.0f) { Speed = 0.0f; }
        UiManager.Instance.showSpeed();
    }
}
