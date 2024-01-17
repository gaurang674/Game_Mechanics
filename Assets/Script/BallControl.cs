using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public GameObject powerUpIndi;
    public float powerUpForce = 16f;
    public bool hasPowerUp = false;
    float verticalAxis;
    Rigidbody rb;
    public CameraMovement Camera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        rb.AddForce(Camera.transform.forward * 4f * verticalAxis );
        powerUpIndi.transform.position = transform.position + new Vector3(0, -0.2f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerUpIndi.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(countDown());
        }
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndi.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(forceDirection * powerUpForce, ForceMode.Impulse);
        }
    }
}
