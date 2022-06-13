using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    public float powerupStrength = 15.0f;

    Rigidbody playerRB;
    GameObject focalPoint;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
      
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);

        //Debug.Log("powerup: " + hasPowerup);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPLayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("collide with " + collision.gameObject.name + " with powereup set to " + hasPowerup);
        
        }
        
    }
}
