using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    private GameManager gameManager;
    private float bound = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (transform.position.y > bound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -bound)
        {
            Destroy(gameObject);   
        }

    }
}
