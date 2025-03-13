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
}
