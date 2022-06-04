using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogControl : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject player;

    [SerializeField]
    Slider fuelSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameManager.GameState)
        {
            case GameStates.Playing:
                transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0,
                                                                                       player.transform.position.y - transform.position.y, 2.5f),
                                                                                       0.25f);
                break;

            case GameStates.End:
                if(player.transform.position.y < 1.6f)
                {
                    transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0,
                                                                       player.transform.position.y - transform.position.y, 0f),
                                                                       0.05f);
                }
                break;
        }

    }
}
