using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstJump : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playerScript = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GameState == GameStates.Playing && playerScript.ZiplamaHakki < 4)
        {
            gameObject.SetActive(false);
        }
    }
}
