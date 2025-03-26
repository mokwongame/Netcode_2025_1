using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text textSpeed; // 필드로 선언

    private static UiManager _instance = null;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null) Debug.Log("UiManager is null.");
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //showSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.Log("UiManager has another instance.");
            Destroy(gameObject);
        }
    }

    public void showSpeed()
    {
        string str = $"Speed = {GameManager.Instance.Speed}";
        textSpeed.text = str;
    }
}
