using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float xmin = -9.0f;
    public float xmax = 9.0f;
    int dir = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xoff = dir * GameManager.Instance.Speed * Time.deltaTime;
        Vector3 pos = transform.position;
        if (pos.x <= xmin)
        {
            dir = -1;
        }
        else if (pos.x >= xmax)
        {
            dir = 1;
        }

        transform.Translate(xoff, 0.0f, 0.0f);
    }
}
