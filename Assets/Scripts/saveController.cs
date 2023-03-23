using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveController : MonoBehaviour
{
    public varController vr;


    private void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();

    }




}
