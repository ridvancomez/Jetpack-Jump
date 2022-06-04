using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingWhite : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z);
        transform.localScale = new Vector3(playerTransform.position.y, transform.localScale.y, playerTransform.position.y);
    }
}
