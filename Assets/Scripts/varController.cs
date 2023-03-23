using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class varController : MonoBehaviour
{
    public System.DateTime dt;
    private calanderController cl;
    private dayController dl;

    public int level = 1;
    public float speedStat;
    public float healthStat;
    public float damageStat;
    public float attackSpeedStat;

    public int coins;

    public int attributePoints;

    public Sprite tile;
    public AnimationClip hat;

    public List<Sprite> purchasedTiles;
    public List<AnimationClip> purchasedAnimations;


    [System.Serializable]

    public struct tasksDict
    {
        public int year;
        public int month;
        public int day;
        public string val;
        public int savedStatus;
        public int status { get; set; }
        [SerializeField]
        public System.DateTime dt;
    }
    [SerializeField]
    public List<tasksDict> tasks;

    [SerializeField]
    public class savedData
    {
        public List<tasksDict> tasksSave;
        public int levelSave;
        public float speedSave;
        public float healthSave;
        public float damageSave;
        public float attackSpeedSave;
        public int coinsSave;
        public int attributeSave;
        public Sprite tileSave;
        public AnimationClip hatSave;
        public List<Sprite> purchasedTilesSave;
        public List<AnimationClip> purchasedAnimationsSave;

        public savedData()
        {
            this.tasksSave = null;
            this.levelSave = 1;
            this.speedSave = 1;
            this.healthSave = 1;
            this.damageSave = 3;
            this.attackSpeedSave = 1;
            this.coinsSave = 0;
            this.attributeSave = 0;

            this.purchasedTilesSave = null;
            this.purchasedAnimationsSave = null;
        }
    }

    public void saveData()
    {
        savedData save = new savedData();
        save.tasksSave = tasks;
        save.levelSave = level;
        save.speedSave = speedStat;
        save.healthSave = healthStat;
        save.damageSave = damageStat;
        save.attackSpeedSave = attackSpeedStat;
        save.coinsSave = coins;
        save.attributeSave = attributePoints;
        save.tileSave = tile;
        save.hatSave = hat;
        save.purchasedTilesSave = purchasedTiles;
        save.purchasedAnimationsSave = purchasedAnimations;

        //Directory.CreateDirectory(Application.persistentDataPath + '\\' + "saveData.json");
        string toStore = JsonUtility.ToJson(save, true);
        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath + "saveData.txt"), FileMode.OpenOrCreate))
        {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(toStore);
                    writer.Close();
                }
        }
    }
    private void loadData(savedData save)
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath + "saveData.txt")))
        {
            string toLoad = "";
            using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath + "saveData.txt"), FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    toLoad = reader.ReadToEnd();
                    reader.Close();
                }
            }
            
            save = JsonUtility.FromJson<savedData>(toLoad);

            tasks = save.tasksSave;
            level = save.levelSave;
            speedStat = save.speedSave;
            healthStat = save.healthSave;
            damageStat = save.damageSave;
            attackSpeedStat = save.attackSpeedSave;
            coins = save.coinsSave;
            attributePoints = save.attributeSave;
            tile = save.tileSave;
            hat = save.hatSave;
            purchasedTiles = save.purchasedTilesSave;
            purchasedAnimations = save.purchasedAnimationsSave;

            GameObject cos = GameObject.FindGameObjectWithTag("cosController");
            cos.SendMessage("setCos");
            GameObject lev = GameObject.FindGameObjectWithTag("levelController");
            lev.SendMessage("setLevel");
        }
    }

    private void OnApplicationQuit()
    {
        saveData();
    }

    private void Start()
    {
        savedData load = new savedData();
        loadData(load);
        saveData();
    }

    public void addTask(int y, int m, int d, string v, System.DateTime dt, int status = 0)
    {
        tasksDict tsk = new tasksDict();
        tsk.year = y;
        tsk.month = m;
        tsk.day = d;
        tsk.val = v;
        tsk.status = status;
        tsk.dt = dt;
        tasks.Add(tsk);
        saveData();
    }




    public void getMonthTasks(int y, int m)
    {
        cl = GameObject.FindGameObjectWithTag("cal").GetComponent<calanderController>();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].year == y)
            {
                if (tasks[i].month == m)
                {
                    cl.addTask(tasks[i].year, tasks[i].month ,tasks[i].day, tasks[i].val, tasks[i].savedStatus, tasks[i].dt);
                }
            }
        }
    }
    public void getDayTasks(int y, int m, int d)
    {
        dl = GameObject.FindGameObjectWithTag("day").GetComponent<dayController>();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].year == y)
            {
                if (tasks[i].month == m)
                {
                    if (tasks[i].day == d)
                    {
                        dl.addSavedTask(tasks[i].val,tasks[i].savedStatus);
                    }
                }
            }
        }
    }

    public void replaceTask(int y, int m, int d, string v, int status)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].year == y)
            {
                if (tasks[i].month == m)
                {
                    if (tasks[i].day == d)
                    {
                        if(tasks[i].val == v)
                        {
                            tasksDict tsk = tasks[i];
                            tsk.status = status;
                            tsk.savedStatus = status;
                            tasks[i] = tsk;
                            if (status == 1)
                            {
                                level += 1;
                                attributePoints += 3;
                                saveData();
                            }
                        }
                    }
                }
            }
        }
    }


    public void addCoin()
    {
        coins += 1;
        TMP_Text txt = GameObject.FindGameObjectWithTag("coin").transform.GetChild(1).GetComponent<TMP_Text>();
        txt.text = coins.ToString();
        saveData();
    }

}

