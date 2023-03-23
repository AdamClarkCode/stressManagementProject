using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tileInfo : MonoBehaviour
{
    public bool purchased;
    public int cost;
    private varController vr;
    public bool hat;

    // Start is called before the first frame update
    void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        if (hat)
        {
            if (vr.purchasedAnimations.Contains(this.GetComponent<Animation>().clip))
            {
                purchased = true;
                this.transform.parent.GetChild(1).GetComponent<TMP_Text>().text = "";
            }
        }
        else if (vr.purchasedTiles.Contains(this.GetComponent<Image>().sprite))
        {
            purchased = true;
            this.transform.parent.GetChild(1).GetComponent<TMP_Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
