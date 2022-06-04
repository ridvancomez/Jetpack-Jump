using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameStates { Start, Preparation, Playing, End, Final }
public class GameManager : MonoBehaviour
{
    bool coroutineRun = false;

    internal GameStates GameState { get; private set; }
    private GameObject player;

    private bool firstGame;

    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject endPanel;

    [SerializeField]
    private GameObject firstInstructivePanel;

    [SerializeField]
    private GameObject secondInstructivePanel;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private TextMeshProUGUI readyGoText;

    private GameObject ring;

    [SerializeField]
    private GameObject scoreLine;
    // Start is called before the first frame update
    void Start()
    {
        ring = GameObject.FindObjectOfType<Ring>().gameObject;
        readyGoText.text = "";
        firstInstructivePanel.SetActive(false);
        secondInstructivePanel.SetActive(false);
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        firstGame = true;
        GameState = GameStates.Start;
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case GameStates.Start:
                GameStart();
                break;
            case GameStates.Preparation:
                GamePreparation();
                break;
            case GameStates.Playing:
                GamePlaying();
                break;
            case GameStates.End:
                GameEnd();
                break;
            case GameStates.Final:
                GameFinal();
                break;
        }

      
    }

    internal void ChangeState(GameStates differentState)
    {
        GameState = differentState;
    }

    public void ButtonChangeState()
    {
        if (GameState == GameStates.Preparation)
        {
            player.GetComponent<Animator>().SetBool("Run", true);
            GameState = GameStates.Playing;

        }
        else if (GameState == GameStates.End)
        {
            Time.timeScale = 1;
            secondInstructivePanel.SetActive(false);
        }
    }

    public void ReStrart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameStart()
    {
        finalPanel.SetActive(false);
        scoreLine.SetActive(false);
        if (Input.GetMouseButtonDown(0))
        {
            startPanel.SetActive(false);
            player.GetComponent<Animator>().SetBool("Prepartion", true);
            GameState = GameStates.Preparation;
        }
    }

    private void GamePreparation()
    {
        if (player.GetComponent<Turned>().hazir)
        {
            if (firstGame)
            {
                firstInstructivePanel.SetActive(true);
            }
            else if (!coroutineRun)
            {
                StartCoroutine("ReadyGo");
                coroutineRun = true;
            }
        }
    }

    private void GamePlaying()
    {
        firstInstructivePanel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;

        if(player.GetComponent<PlayerController>().ZiplamaHakki ==1)
        {
            GameState = GameStates.End;
        }

    }

    private void GameEnd()
    {
        if(firstGame)
        {
            secondInstructivePanel.SetActive(true);
            Time.timeScale = 0;
            firstGame = false;
        }
        ring.SetActive(false);
        scoreLine.SetActive(true);
        endPanel.SetActive(true);
        player.GetComponent<Animator>().SetBool("End", true);
    }

    private void GameFinal()
    {
        StartCoroutine("GetFinalPanel");
    }


    IEnumerator ReadyGo()
    {
        readyGoText.text = "READY?";
        yield return new WaitForSeconds(1);
        readyGoText.text = "Go";
        yield return new WaitForSeconds(1);
        readyGoText.text = "";
        player.GetComponent<Animator>().SetBool("Run", true);
        GameState = GameStates.Playing;
    }

    private IEnumerator GetFinalPanel()
    {
        yield return new WaitForSeconds(4);
        finalPanel.SetActive(true);

    }
}
