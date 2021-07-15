using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 35.0f;
    private float Range = 10.0f;
    public bool hasPowerup= false;
    public GameObject powerupIndicator;
    public GameObject projectile;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public AudioClip explosion;
    public AudioClip shoot;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (transform.position.x < -Range)
        {
            transform.position = new Vector3(-Range, transform.position.y, transform.position.z);
        }

        if (transform.position.x > Range)
        {
            transform.position = new Vector3(Range, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile from player
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            playerAudio.PlayOneShot(shoot, 1.0f);
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        else if (other.CompareTag("bad"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            explosionParticle.Play();
            gameManager.GameOver();
            playerAudio.PlayOneShot(explosion, 1.0f);
        }
    }       

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }
}
