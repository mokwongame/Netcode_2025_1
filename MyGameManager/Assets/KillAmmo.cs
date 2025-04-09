using UnityEngine;

public class KillAmmo : MonoBehaviour
{
    public float killTime = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, killTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
