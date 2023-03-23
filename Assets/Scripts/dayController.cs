using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dayController : MonoBehaviour
{
    private TMPro.TMP_Text dayText;

    private varController vr;
    private System.DateTime dt;

    public List<GameObject> taskBoxes;
    private List<string> dtasks;
    public List<Button> btns;

    private int taskCount = 0;


    void Awake()
    {

        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        dt = vr.dt;
        dayText = GameObject.FindGameObjectWithTag("dayT").GetComponent<TMP_Text>();
        dayText.text = (dt.ToString("M"));
        foreach(GameObject task in taskBoxes) {
            task.SetActive(false);
        }
        vr.getDayTasks(dt.Year, dt.Month, dt.Day);
    }
    public void addNewTask()
    {
        string toset = GameObject.FindGameObjectWithTag("input").GetComponent<TMP_InputField>().textComponent.text;
        taskBoxes[taskCount].SetActive(true);
        Button btn = taskBoxes[taskCount].transform.GetChild(1).GetComponent<Button>();
        setUpButton(btn,taskCount);
        TMP_Text txt = taskBoxes[taskCount].transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
        txt.text = toset;
        vr.addTask(dt.Year,dt.Month,dt.Day,txt.text,dt);
        taskCount += 1;
    }
    public void addSavedTask(string val, int status)
    {
        taskBoxes[taskCount].SetActive(true);
        Button btn = taskBoxes[taskCount].transform.GetChild(1).GetComponent<Button>();
        setUpButton(btn, taskCount);
        if (status == 1)
        {
            completeTask(taskBoxes[taskCount],taskCount);
        }

        TMP_Text txt = taskBoxes[taskCount].transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
        txt.text = val;
        taskCount += 1;

    }

    public void completeTask(GameObject task, int taskCount)
    {
        Image img = taskBoxes[taskCount].GetComponent<Image>();
        if (img.color != Color.green)
        {
            img.color = Color.green;
            vr.replaceTask(dt.Year, dt.Month, dt.Day, task.transform.GetChild(0).GetComponent<TMP_Text>().text, 1);
        }
    }

    void setUpButton(Button btn, int taskCount) 
    {
        btns.Add(btn);
        btn.onClick.AddListener(delegate { completeTask(taskBoxes[taskCount],taskCount);});
    }


}
