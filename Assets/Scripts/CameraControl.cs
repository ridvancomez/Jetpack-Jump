using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameManager gameManager;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playerTransform = GameObject.FindObjectOfType<PlayerController>().gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(gameManager.GameState == GameStates.Preparation)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.15f, 4f, -56), 0.03f);
        }
        if(gameManager.GameState != GameStates.Start && gameManager.GameState != GameStates.Preparation) //diðer üçü ise
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position - new Vector3(-1.15f, -2.5f, 7f), 0.5f);
        }
    }
}
