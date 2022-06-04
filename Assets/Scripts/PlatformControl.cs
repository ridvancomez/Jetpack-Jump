using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z +100 < player.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +800);
        }
    }
}
