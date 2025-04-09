using UnityEngine;

public class HitTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy is hit.");
            Destroy(gameObject, 0.5f);
            GameManager.Instance.PlayerScore++;
            GameManager.Instance.EnemyScore--;
            Debug.Log($"player = {GameManager.Instance.PlayerScore}, enemy = {GameManager.Instance.EnemyScore}");
        }
    }
}
