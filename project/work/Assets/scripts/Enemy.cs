using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject eprojectile;
    public float speed = 40.0f;
    public bool gameOver = false;
    private GameManager gameManager;
    public AudioClip explosion;
    private AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        startshooting();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

    }
    void startshooting()
    {
        
             eprojectile = Instantiate(eprojectile, transform.position, eprojectile.transform.rotation);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            enemyAudio.PlayOneShot(explosion, 1.0f);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

