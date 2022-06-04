using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Gold", 0).ToString();
    }
}
