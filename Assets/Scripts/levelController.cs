using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelController : MonoBehaviour
{
    private varController vr;
    private TMP_Text txt;

    private TMP_Text attTxt;

    private void Awake()
    {
        setLevel();
    }

    void setLevel()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        txt = GameObject.FindGameObjectWithTag("lvlTxt").GetComponent<TMP_Text>();
        txt.text = ("Level: " + vr.level);

        attTxt = GameObject.FindGameObjectWithTag("attributePoints").GetComponent<TMP_Text>();
        attTxt.text = vr.attributePoints.ToString();

    }
}
