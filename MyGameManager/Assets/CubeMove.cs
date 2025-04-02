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
        // 필드인 경우 접근
        //float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.speed * Time.deltaTime; // speed*시간 = 거리
        //float zoff = Input.GetAxis("Vertical") * GameManager.Instance.speed * Time.deltaTime;

        // 프로퍼티 접근
        float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.Speed * Time.deltaTime; // speed*시간 = 거리
        float zoff = Input.GetAxis("Vertical") * GameManager.Instance.Speed * Time.deltaTime;

        // CubeMove 클래스를 실행한 인스턴스는 gameObject(인스턴스)에 저장; gameObject의 클래스는 GameObject
        // 원칙: gameObject.transform으로 접근
        // 간략화: 그냥 transform 인스턴스로 접근; transform의 클래스는 Transform
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
