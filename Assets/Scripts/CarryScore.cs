using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarryScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + Convert.ToInt32(scoreText.text.Substring(0, scoreText.text.Length - 2)));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = scoreText.text;
    }
}
