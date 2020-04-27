using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalpoint;
    public float speed = 5.0f;
    private float powerupStrength = 15.0f;
    public bool hasPowerup=false;
    public GameObject PowerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardinput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalpoint.transform.forward * forwardinput * speed);
        PowerupIndicator.transform.position = transform.position+new Vector3(0,-0.5f,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            PowerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCoundownRoutine());
        }
        IEnumerator PowerupCoundownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            PowerupIndicator.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerup)
        {
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigibody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collider with: " + collision.gameObject.name + " With power set to " + hasPowerup);
        }
    }

}
