using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private float speed;
    private GameManager gameManager;
    public int ZiplamaHakki;
    Animator animator;
    Rigidbody rb;
    private float beklemeSuresi;

    [SerializeField]
    private TextMeshProUGUI PerfectGoodOK;

    [SerializeField]
    private Slider fuelSlider;

    [SerializeField]
    private ParticleSystem boost;

    [SerializeField]
    private PhysicMaterial endMaterial;


    float ziplamaCarpani;
    public bool isGrounded;

    private void Awake()
    {
        ZiplamaHakki = 4;
    }


    void Start()
    {
        PerfectGoodOK.text = "";
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ziplamaCarpani = 1;
        speed = 5;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {


        WhicState(gameManager.GameState);

    }


    private void WhicState(GameStates currentState)
    {
        switch (currentState)
        {
            case GameStates.Start:
                StateStart();
                break;
            case GameStates.Playing:
                StatePlaying();
                break;
            case GameStates.End:
                StateEnd();
                break;
            case GameStates.Final:
                StateFinal();
                break;
        }
    }

    private void StateStart()
    {
    }

    private void StatePlaying()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            isGrounded = false;
            animator.SetTrigger("Jump");
            if (beklemeSuresi < 0.25f)
            {
                PerfectGoodOK.text = "Good";
                
            }
            else if (beklemeSuresi < 0.6f)
            {
                PerfectGoodOK.text = "Perfect";
            }
            else if (beklemeSuresi <= 1.8f)
            {
                PerfectGoodOK.text = "OK";

            }
            StartCoroutine("PerfectGoodOKText");

            beklemeSuresi = 0;
            ZiplamaHakki--;
            rb.AddForce(new Vector3(0, 1, 1) * 7.5f * ziplamaCarpani, ForceMode.Impulse);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.y <= 2.5f && ZiplamaHakki <= 2)
        {
            beklemeSuresi += Time.deltaTime;
        }


    }
    private void StateEnd()
    {
        Debug.Log("enddeyim");
        GetComponent<Collider>().material = (PhysicMaterial)endMaterial;
        if (gameManager.GameState == GameStates.End && Input.GetMouseButton(0) && fuelSlider.value > 0)
        {
            fuelSlider.value -= Time.deltaTime;
            boost.Play();
            rb.AddForce(new Vector3(0, 1, 1) * 0.5f, ForceMode.Impulse);
        }
        else
        {
            boost.Pause();
        }
    }
    private void StateFinal()
    {

    }
    IEnumerator PerfectGoodOKText()
    {
        yield return new WaitForSeconds(1);
        PerfectGoodOK.text = "";

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dog")
        {
            rb.AddForce(new Vector3(0, 1, 1) * 7.5f * ziplamaCarpani, ForceMode.Impulse);
            gameManager.ChangeState(GameStates.Final);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Yol")
        {
            isGrounded = true;
        }
    }

}
