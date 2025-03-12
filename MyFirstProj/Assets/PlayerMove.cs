using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // player ����
    public float speed = 1.0f; // �� �����Ӵ� �����̴� ����Ƽ ����(unit)
    // �ӵ� = �Ÿ�/�ð�; �ӵ�*�ð� = ������ �Ÿ�
    // ���ӿ��� ����ϴ� �ð�: Time.deltaTime(�� �������� �׸� �� �ʿ��� �ð�)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ����� �޽��� ���
        Debug.Log("PlayerMove start.");
    }

    // Update is called once per frame
    void Update()
    {
        float xoff = speed*Time.deltaTime;
        float zoff = speed * Time.deltaTime;
        // ���� PlayerMove ��ũ��Ʈ�� �����ϴ� ���� ������Ʈ GameObject�� �ν��Ͻ�: gameObject
        // ����� gameObject�� ����� Transform �ν��Ͻ�: transform
        // ��Ģ: gameObject.transform.Translate();
        // ����ȭ�� �ڵ�
        transform.Translate(xoff, 0.0f, zoff); // Translate(): Transform�� �޼ҵ�(�Լ�) -> ���� �̵��ϴ� �Լ�
    }
}
