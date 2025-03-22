using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
    public TMP_Text textSpeed;

    private static UiManager _instance;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UiManager is null.");
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; // 현재 UiManager의 인스턴스
        }
        else if (_instance != this)
        {
            Debug.Log("UiManager has another instance.");
            Destroy(gameObject); // 현재 인스턴스와 Singleton의 인스턴스가 다르면 파괴
        }
    }

    public void showSpeed()
    {
        string str = $"Speed = {GameManager.Instance.Speed}";
        textSpeed.text = str;
    }

    public void incSpeed()
    {
        GameManager.Instance.incSpeed();
        showSpeed();
    }

    public void decSpeed()
    {
        GameManager.Instance.decSpeed();
        showSpeed();
    }
}
