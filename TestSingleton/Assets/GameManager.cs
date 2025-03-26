using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ��� ����: �ʵ�(field)
    private static GameManager _instance = null; // static �ǹ�: class�� �ν��Ͻ� ������ ������� �� ������ �ѹ��� ����(�޸� �Ҵ�)
    public static GameManager Instance // ����(�ʵ�) + �Լ�(�޼ҵ�): ������Ƽ(�ܼ� �� ���� ����ó�� ������ ���ο� ������ �޼ҵ带 ����)
    {
        // get �޼ҵ�
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

    // �ʵ� -> getter, setter
    //private float speed = 10.0f; // �� �����Ӵ� �����̴� ���� �� = ��ü�� �ӵ�
    //public float getSpeed() { return speed; } // getter
    //public void setSpeed(float speed) { this.speed = speed; } // setter
    float speedStep = 1.0f;

    // ������Ƽ: ���� + �Լ�
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
            _instance = this; // ���� GameObject�� �ν��Ͻ�
            initParam();
        }
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            Destroy(gameObject); // ���� �ν��Ͻ��� Singleton�� �ν��Ͻ��� �ٸ��� �ı�
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
