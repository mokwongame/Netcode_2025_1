using UnityEngine;
using Unity.Netcode;

public class MoveTank : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float zoff = Input.GetAxis("Vertical") * GameManager.Instance.SpeedTank * Time.deltaTime;
        transform.Translate(0.0f, 0.0f, zoff);
        float angoff = Input.GetAxis("Horizontal") * GameManager.Instance.RotSpeedTank * Time.deltaTime;
        transform.Rotate(0.0f, angoff, 0.0f);
    }
}
