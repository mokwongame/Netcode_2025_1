using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 멤버 변수: 필드(field)
    private static GameManager _instance = null; // static 의미: class의 인스턴스 생성과 관계없이 이 변수는 한번만 생성(메모리 할당)
    public static GameManager Instance // 변수(필드) + 함수(메소드): 프로퍼티(외수 쓸 때는 변수처럼 쓰지만 내부에 구성은 메소드를 가짐)
    {
        // get 메소드
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null.");
            }
            return _instance;
        }
    }
    public static Color[] colors = { Color.black, Color.red, Color.green, Color.blue, Color.white, Color.gray };

    // 필드 -> getter, setter
    //private float speed = 10.0f; // 한 프레임당 움직이는 유닛 수 = 객체의 속도
    //public float getSpeed() { return speed; } // getter
    //public void setSpeed(float speed) { this.speed = speed; } // setter
    float speedStep = 1.0f;

    // 프로퍼티: 변수 + 함수
    public float Speed { get; set; }

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
        {
            _instance = this; // 현재 GameObject의 인스턴스
            initParam();
        }
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            Destroy(gameObject); // 현재 인스턴스와 Singleton의 인스턴스가 다르면 파괴
        }
        DontDestroyOnLoad(gameObject);
    }

    void initParam()
    {
        Speed = 10.0f;
    }

    public void incSpeed()
    {
        Speed += speedStep;
    }

    public void decSpeed()
    {
        Speed -= speedStep;
        if (Speed < 0.0f) Speed = 0.0f;
    }

    public int getNextColorIdx(int colorIdx)
    {
        //colorIdx++;
        //if (colorIdx >= colors.Length) colorIdx = 0;
        //return colorIdx;
        return (colorIdx + 1) % colors.Length;
    }

    public int getPrevColorIdx(int colorIdx)
    {
        colorIdx = colorIdx - 1;
        if (colorIdx < 0) colorIdx = colors.Length - 1;
        return colorIdx;
    }

    public Color getNextColor(ref int colorIdx)
    {
        colorIdx = getNextColorIdx(colorIdx);
        return colorIdxToColor(colorIdx);
    }

    public Color getPrevColor(ref int colorIdx)
    {
        colorIdx = getPrevColorIdx(colorIdx);
        return colorIdxToColor(colorIdx);
    }

    public Color colorIdxToColor(int colorIdx)
    {
        return colors[colorIdx];
    }
}
