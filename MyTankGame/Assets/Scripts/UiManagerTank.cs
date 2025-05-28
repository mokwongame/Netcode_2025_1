using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManagerTank : MonoBehaviour
{
    public TMP_Text textUserInfo;
    public Slider sliderHealth;

    public int health = 0;
    public int maxHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.startNode();
        GameManager.Instance.updateCountId();
        health = maxHealth;
        updateTextUserInfo();
        updateSliderHealth();
        Invoke("checkCountId", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateTextUserInfo()
    {
        textUserInfo.text = $"{GameManager.Instance.CountId}:{GameManager.Instance.UserId}={health}";
    }

    public void updateSliderHealth()
    {
        sliderHealth.value = health;
    }

    void checkCountId()
    {
        GameManager.Instance.updateCountId();
        updateTextUserInfo();
    }
}
