using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject plane;
    bool prevClick = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (prevClick && Input.GetAxis("Fire1") != 0.0f) // Fire1: ���콺 ��Ŭ��
        {
            float angOff = Input.GetAxis("Mouse X") * GameManager.Instance.CameraSpeed * Time.deltaTime; // ���콺�� x����(���� ����)���� ������
            transform.RotateAround(plane.transform.position, plane.transform.up, angOff);
        }
        prevClick = (Input.GetAxis("Fire1") != 0.0f) ? true : false;
    }
}
