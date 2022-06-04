using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLine : MonoBehaviour
{
    private TextMeshPro childObjectText;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        childObjectText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        childObjectText.text = (49 + player.transform.position.z).ToString("00.0");
    }

    
}
