using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class gameController : MonoBehaviour
{
    varController vr;
    TMP_Text cointext;
    void Awake()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        cointext = GameObject.FindGameObjectWithTag("coin").transform.GetChild(1).GetComponent<TMP_Text>();
        cointext.text = vr.coins.ToString();
    }

}
