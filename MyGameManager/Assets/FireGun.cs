using UnityEngine;

public class FireGun : MonoBehaviour
{
    public GameObject ammo; // ammunition

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireGun();
        }
    }

    void fireGun()
    {
        GameObject newAmmo = Instantiate(ammo, transform.position, transform.rotation);
        Transform parentTf = transform.parent;
        Renderer renderer = newAmmo.GetComponent<Renderer>();
        renderer.material.color = parentTf.GetComponent<Renderer>().material.color;
        Rigidbody rb = newAmmo.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * GameManager.Instance.AmmoForce);
    }
}
