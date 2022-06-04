using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turned : MonoBehaviour
{
    public bool hazir;

    private GameManager gameManager;
    private Animator animator;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        hazir = false;
    }

    // Update is called once per frame
    void Update()
    {


        if(gameManager.GameState == GameStates.Preparation)
        {
            animator.applyRootMotion = true;

            if (transform.rotation.y % 360 <= 0)
            {
                animator.applyRootMotion = false;
                rb.isKinematic = false;
                animator.SetBool("Ready", true);
                transform.rotation = Quaternion.Euler(new Vector3( transform.rotation.x, 0, transform.rotation.z));
                hazir = true;
                
            }
        }
    }

}
