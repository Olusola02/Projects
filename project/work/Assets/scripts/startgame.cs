using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startgame : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(Startgame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Startgame()
    {
        Debug.Log(gameObject.name + "was clicked");
        gameManager.StartGame();
    }
}
