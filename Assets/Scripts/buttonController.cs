using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{
    private Button btn;
    private uiControllerScript ui;
    private varController vr;

    private void Start()
    {
  
    }

    void Awake()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(dayScreen);
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        ui = GameObject.FindGameObjectWithTag("uiController").GetComponent<uiControllerScript>();
    }

    private void dayScreen()
    {
        vr.dt = this.gameObject.GetComponent<dayVars>().dt;
        //vr.tasks = this.gameObject.GetComponent<dayVars>().tasks;
        ui.dSwitch();
    }
}
