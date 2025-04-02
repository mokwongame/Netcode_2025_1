using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text textSpeed; // 필드로 선언
    private Color[] colors = { Color.white, Color.red, Color.green, Color.blue, new Color(0.5f, 0.25f, 0.25f) };
    private int tankColorIndex = 0;
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

    public Color indexToColor(int index)
    {
        return colors[index];
    }

    public Color getNextColor()
    {
        tankColorIndex++;
        if (tankColorIndex >= colors.Length) tankColorIndex = 0;
        return indexToColor(tankColorIndex);
    }
}
