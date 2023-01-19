using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class uiControllerScript : MonoBehaviour
{
    public List<Button> btns;


    void Awake()
    {
        btns.Add(GameObject.FindGameObjectWithTag("Jbutton").GetComponent<Button>());
        btns.Add(GameObject.FindGameObjectWithTag("Dbutton").GetComponent<Button>());
        Button Jbtn = btns[0];
        Button Dbtn = btns[1];
        Jbtn.onClick.AddListener(jswitch);
        Dbtn.onClick.AddListener(delveswitch);
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode single)
    {
        btns.Clear();
        if (scene.name == "journalScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Bbutton").GetComponent<Button>());
            Button Bbtn = btns[0];

            Bbtn.onClick.AddListener(mswitch);
        }
        if(scene.name == "mainScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Jbutton").GetComponent<Button>());
            btns.Add(GameObject.FindGameObjectWithTag("Dbutton").GetComponent<Button>());
            Button Jbtn = btns[0];
            Button Dbtn = btns[1];
            Jbtn.onClick.AddListener(jswitch);
            Dbtn.onClick.AddListener(delveswitch);
        }
        if(scene.name == "dayScene")
        {
            btns.Add(GameObject.FindGameObjectWithTag("Bbutton").GetComponent<Button>());
            Button Bbtn = btns[0];
            Bbtn.onClick.AddListener(jswitch);
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void jswitch()
    {
        SceneManager.LoadScene("journalScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void mswitch()
    {
        SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void dswitch()
    {
        SceneManager.LoadScene("dayScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void delveswitch()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

}
