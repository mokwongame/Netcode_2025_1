using UnityEngine;

public class MoveObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.Speed;
        float xoff = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // x�� �������� ������ �Ÿ�(����)
        float zoff = Input.GetAxis("Vertical") * speed * Time.deltaTime; // z�� �������� ������ �Ÿ�(����)
        transform.Translate(xoff, 0.0f, zoff);
    }
}
