using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public float speed = 10.0f; // �ʵ�; public�ϸ� ��ü ������ ö�а� ��������
    public float Speed // ������Ƽ
    { get; set; }
    public float SpeedStep
    { get; set; }

    // singleton pattern: Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� �����׷��� ����
    private static GameManager _instance = null; // ��� ���� ����, ���� = �ʵ�(field) ���� ->  �ܺ� ���� �Ұ�(private, protected ����)
    public static GameManager Instance // ���� + �Լ� = �ʵ� + �޼ҵ� = ������Ƽ(property) -> �ܺ� ������ �����ϰ�(public ����), �ܺο����� ����ó�� ���
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
            _instance = this; // this: ���� �ν��Ͻ��� ����Ű�� ���۷���
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            // ���� �ν��Ͻ� �ı�
            Destroy(gameObject);
        }
        // ���� �ٲ� ���� ���� ������Ʈ�� ����
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
