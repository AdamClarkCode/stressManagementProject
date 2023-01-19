using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class calanderController : MonoBehaviour
{
    private TMPro.TMP_Text monthText;
    public List<Button> changeButtons;
    public System.DateTime cur;

    public List<GameObject> pannels;


    void Start()
    {
        monthText = GameObject.FindGameObjectWithTag("monthT").GetComponent<TMP_Text>();
        monthText.text = (System.DateTime.Now.ToString("Y"));
        cur = System.DateTime.Now;
        changeMonth(cur);
        Button backbtn = changeButtons[0];
        Button forwardbtn = changeButtons[1];
        backbtn.onClick.AddListener(bck);
        forwardbtn.onClick.AddListener(frwd);


    }
    private void bck()
    {
        cur = cur.AddMonths(-1);
        monthText.text = cur.ToString("Y");
        changeMonth(cur);
    }
    private void frwd()
    {
        cur = cur.AddMonths(1);
        monthText.text = cur.ToString("Y");
        changeMonth(cur);
    }

    private void changeMonth(System.DateTime i, Image p = null)
    {
        string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        int index =0;
        System.DateTime first = new System.DateTime(i.Year, i.Month, 1);
        string output = first.ToString("ddd");
        for (int d = 0; d < 7; d++)
        {
            if (days[d] == output)
            {
                index = d;
            }
        }
        for (int count = 0; count < pannels.Count; count++)
        {
            if (count < System.DateTime.DaysInMonth(first.Year, first.Month) + index && count >= index){
                pannels[count].transform.GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>().text = (count-index + 1).ToString();
                dayVars dV = pannels[count].transform.GetChild(0).GetComponent<dayVars>();
                dV.dt = new System.DateTime(first.Year, first.Month, count - index + 1);
                
            }
            else
            {
                pannels[count].transform.GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>().text = "";
            }
        }
    }


}
