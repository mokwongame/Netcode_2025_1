using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speed = 10.0f;

    // singleton pattern: Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� �����׷��� ����
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
            _instance = this; // this: ���� �ν��Ͻ��� ����Ű�� ���۷���
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            // ���� �ν��Ͻ� �ı�
            Destroy(gameObject);
        }
    }
}
