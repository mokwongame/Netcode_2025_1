using UnityEngine;

public class MoveObj : MonoBehaviour
{
    int colorIdx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.Speed;
        float xoff = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // x축 방향으로 움직인 거리(유닛)
        float zoff = Input.GetAxis("Vertical") * speed * Time.deltaTime; // z축 방향으로 움직인 거리(유닛)
        transform.Translate(xoff, 0.0f, zoff);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setNextColor();
        }
    }

    public void setNextColor()
    {
        //colorIdx = GameManager.Instance.getNextColorIdx(colorIdx);
        //Renderer rend = GetComponent<Renderer>();
        //rend.material.color = GameManager.Instance.colorIdxToColor(colorIdx);
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = GameManager.Instance.getNextColor(ref colorIdx);
    }

    public void setPrevColor()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = GameManager.Instance.getPrevColor(ref colorIdx);
    }
}
