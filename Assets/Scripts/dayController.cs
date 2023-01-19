using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dayController : MonoBehaviour
{
    private TMPro.TMP_Text dayText;
    private System.DateTime dt;
    void Awake()
    {
        dt = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>().dt;
        dayText = GameObject.FindGameObjectWithTag("dayT").GetComponent<TMP_Text>();
        dayText.text = (dt.ToString("M"));
    }


}
