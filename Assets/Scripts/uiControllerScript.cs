using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class uiControllerScript : MonoBehaviour
{
    public List<Button> btns;
    private varController vr;
    private TMP_Text attTxt;
    private void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
    }

    void Awake()
    {
        btns.Add(GameObject.FindGameObjectWithTag("Jbutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("Dbutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("Sbutton").GetComponent<Button>());

        btns.Add(GameObject.FindGameObjectWithTag("Speedbutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("Healthbutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("Damagebutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("AttackSpeedbutton").GetComponent<Button>());

        Button Jbtn = btns[0];
        Button Dbtn = btns[1];
        Button Sbtn = btns[2];

        Jbtn.onClick.AddListener(jSwitch);
        Dbtn.onClick.AddListener(delveSwitch);
        Sbtn.onClick.AddListener(sSwitch);

        Button speedbtn = btns[3];
        Button healthbtn = btns[4];
        Button damagebtn = btns[5];
        Button attackspeedbtn = btns[6];

        speedbtn.onClick.AddListener(speedup);
        healthbtn.onClick.AddListener(healthup);
        damagebtn.onClick.AddListener(damageup);
        attackspeedbtn.onClick.AddListener(attackspeedup);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode single)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        btns.Clear();
        if (scene.name == "journalScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Bbutton").GetComponent<Button>());
            Button Bbtn = btns[0];

            Bbtn.onClick.AddListener(mSwitch);
        }
        if (scene.name == "mainScene")
        {
            Debug.Log(1);
            btns.Add(GameObject.FindGameObjectWithTag("Jbutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("Dbutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("Sbutton").GetComponent<Button>());

            btns.Add(GameObject.FindGameObjectWithTag("Speedbutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("Healthbutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("Damagebutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("AttackSpeedbutton").GetComponent<Button>());
            Button Jbtn = btns[0];
            Button Dbtn = btns[1];
            Button Sbtn = btns[2];
            Button speedbtn = btns[3];
            Button healthbtn = btns[4];
            Button damagebtn = btns[5];
            Button attackspeedbtn = btns[6];

            Jbtn.onClick.AddListener(jSwitch);
            Dbtn.onClick.AddListener(delveSwitch);
            Sbtn.onClick.AddListener(sSwitch);
            speedbtn.onClick.AddListener(speedup);
            healthbtn.onClick.AddListener(healthup);
            damagebtn.onClick.AddListener(damageup);
            attackspeedbtn.onClick.AddListener(attackspeedup);

        }
        if (scene.name == "dayScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Bbutton").GetComponent<Button>());
            Button Bbtn = btns[0];
            Bbtn.onClick.AddListener(jSwitch);
        }
        if (scene.name == "shopScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Bbutton").GetComponent<Button>());
            Button Bbtn = btns[0];
            Bbtn.onClick.AddListener(mSwitch);
        }

        
    }


    private void jSwitch()
    {
        SceneManager.LoadScene("journalScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void mSwitch()
    {
        SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void dSwitch()
    {
        SceneManager.LoadScene("dayScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void delveSwitch()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void sSwitch()
    {
        SceneManager.LoadScene("shopScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void death()
    {
        SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void speedup()
    {
        if (vr.attributePoints > 0)
        {
            vr.attributePoints -= 1;
            attTxt = GameObject.FindGameObjectWithTag("attributePoints").GetComponent<TMP_Text>();
            attTxt.text = vr.attributePoints.ToString();
            vr.speedStat += 1;
            vr.saveData();
        }
    }
    private void healthup()
    {
        if (vr.attributePoints > 0)
        {
            vr.attributePoints -= 1;
            attTxt = GameObject.FindGameObjectWithTag("attributePoints").GetComponent<TMP_Text>();
            attTxt.text = vr.attributePoints.ToString();
            vr.healthStat += 1;
            vr.saveData();
        }
    }
    private void damageup()
    {
        if (vr.attributePoints > 0)
        {
            vr.attributePoints -= 1;
            attTxt = GameObject.FindGameObjectWithTag("attributePoints").GetComponent<TMP_Text>();
            attTxt.text = vr.attributePoints.ToString();
            vr.damageStat += 1;
            vr.saveData();
        }
    }
    private void attackspeedup()
    {
        if (vr.attributePoints > 0)
        {
            vr.attributePoints -= 1;
            attTxt = GameObject.FindGameObjectWithTag("attributePoints").GetComponent<TMP_Text>();
            attTxt.text = vr.attributePoints.ToString();
            vr.attackSpeedStat += 1;
            vr.saveData();
        }
    }
}
