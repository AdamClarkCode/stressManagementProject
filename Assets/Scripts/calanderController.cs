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
    private varController vr;

    [System.Serializable]
    public struct MnthtasksDict
    {
        public int year;
        public int month;
        public int day;
        public string val;
        public int status;
        public System.DateTime dt;

        public MnthtasksDict(int y, int m, int d, string v, System.DateTime dt, int s = 0)
        {
            this.year = y;
            this.month = m;
            this.day = d;
            this.val = v;
            this.status = s;
            this.dt = dt;
        }
    }
    [SerializeField]
    public List<MnthtasksDict> Mtasks;

    void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
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
        Mtasks.Clear();
        vr.getMonthTasks(cur.Year, cur.Month);
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
            pannels[count].transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
            pannels[count].transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>().color = Color.white;
            pannels[count].transform.GetChild(0).GetChild(3).gameObject.GetComponent<Image>().color = Color.white;


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
        populateMonth(Mtasks, index);
    }

    public void addTask(int month, int year, int day, string text, int status, System.DateTime dt)
    {
        Mtasks.Add(new MnthtasksDict(month, year, day, text, dt, status));
    }

    private void populateMonth(List<MnthtasksDict> tsks, int index)
    {
        for(int j = 0; j<pannels.Count; j++)
        {
            TMP_Text txt = pannels[j].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMPro.TMP_Text>();
            txt.text = "";
            txt = pannels[j].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TMPro.TMP_Text>();
            txt.text = "";
            txt = pannels[j].transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TMPro.TMP_Text>();
            txt.text = "";
        }

        for(int i = 0; i<tsks.Count; i++)
        {
            GameObject pannel = pannels[tsks[i].day + index - 1].transform.GetChild(0).GetChild(1).gameObject;
            TMP_Text txt = pannel.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
            if (txt.text.Length == 0)
            {
                txt.text = tsks[i].val;
                if(tsks[i].status == 1)
                {
                    pannel.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    checkDateTime(tsks[i].year,tsks[i].month,tsks[i].day,pannel.GetComponent<Image>());
                }
            }
            else
            {
                pannel = pannels[tsks[i].day + index - 1].transform.GetChild(0).GetChild(2).gameObject;
                txt = pannel.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
                if (txt.text.Length == 0)
                {
                    txt.text = tsks[i].val;
                    if (tsks[i].status == 1)
                    {
                        pannel.GetComponent<Image>().color = Color.green;
                    }
                    else
                    {
                        checkDateTime(tsks[i].year, tsks[i].month, tsks[i].day, pannel.GetComponent<Image>());
                    }
                }
                else
                {
                    pannel = pannels[tsks[i].day + index - 1].transform.GetChild(0).GetChild(3).gameObject;
                    txt = pannel.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
                    if (txt.text.Length == 0)
                    {
                        txt.text = tsks[i].val;
                        if (tsks[i].status == 1)
                        {
                            pannel.GetComponent<Image>().color = Color.green;
                        }
                        else
                        {
                            checkDateTime(tsks[i].year, tsks[i].month, tsks[i].day, pannel.GetComponent<Image>());
                        }
                    }
                }
            }
        }
    }

    void checkDateTime(int y, int m, int d, Image img)
    {
        if(System.DateTime.Now.Year > y)
        {
            img.color = Color.red;
        }
        if(System.DateTime.Now.Month > m)
        {
            img.color = Color.red;
        }
        else if(System.DateTime.Now.Day > d)
        {
            img.color = Color.red;
        }
    }

}
