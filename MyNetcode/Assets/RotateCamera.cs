using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject plane;
    public float rotSpeed = 300.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") != 0.0f) // Fire1:  ÁÂÅ¬¸¯
        {
            float ang = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
            transform.RotateAround(plane.transform.position, plane.transform.up, ang);
        }

    }
}
