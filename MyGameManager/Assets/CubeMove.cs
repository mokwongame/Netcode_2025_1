using UnityEngine;

public class CubeMove : MonoBehaviour
{
    //public float speed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �ʵ��� ��� ����
        //float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.speed * Time.deltaTime; // speed*�ð� = �Ÿ�
        //float zoff = Input.GetAxis("Vertical") * GameManager.Instance.speed * Time.deltaTime;

        // ������Ƽ ����
        float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.Speed * Time.deltaTime; // speed*�ð� = �Ÿ�
        float zoff = Input.GetAxis("Vertical") * GameManager.Instance.Speed * Time.deltaTime;

        // CubeMove Ŭ������ ������ �ν��Ͻ��� gameObject(�ν��Ͻ�)�� ����; gameObject�� Ŭ������ GameObject
        // ��Ģ: gameObject.transform���� ����
        // ����ȭ: �׳� transform �ν��Ͻ��� ����; transform�� Ŭ������ Transform
        transform.Translate(xoff, 0.0f, zoff);

        if (Input.GetKeyDown(KeyCode.R)) changeColor();
    }

    private void changeColor()
    {
        Color color = UiManager.Instance.getNextColor();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        Transform parentTf = transform;
        while (parentTf.childCount > 0)
        {
            Transform childTf = parentTf.GetChild(0);
            renderer = childTf.GetComponent<Renderer>();
            renderer.material.color = color;
            parentTf = childTf;
        }
    }
}
