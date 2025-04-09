using UnityEngine;

public class RotTurret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float ang = 0.0f;
        if (Input.GetKey(KeyCode.Q))
        {
            ang = -GameManager.Instance.RotSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            ang = GameManager.Instance.RotSpeed * Time.deltaTime;
        }
        ang += 10.0f * Input.mouseScrollDelta.y * GameManager.Instance.RotSpeed * Time.deltaTime;
        transform.Rotate(0.0f, ang, 0.0f);
    }
}
