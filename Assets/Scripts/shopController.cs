using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopController : MonoBehaviour
{
    varController vr;
    public List<Button> tileBtns;
    public List<Button> hatBtns;

    private GameObject currentTile;
    private GameObject currentHat;

    void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        updateCoins();


        tileBtns.Add(GameObject.FindGameObjectWithTag("t1").GetComponent<Button>());
        tileBtns.Add(GameObject.FindGameObjectWithTag("t2").GetComponent<Button>());
        tileBtns.Add(GameObject.FindGameObjectWithTag("t3").GetComponent<Button>());
        Button t1 = tileBtns[0];
        Button t2 = tileBtns[1];
        Button t3 = tileBtns[2];
        t1.onClick.AddListener(t1Switch);
        t2.onClick.AddListener(t2Switch);
        t3.onClick.AddListener(t3Switch);

        hatBtns.Add(GameObject.FindGameObjectWithTag("h1").GetComponent<Button>());
        hatBtns.Add(GameObject.FindGameObjectWithTag("h2").GetComponent<Button>());
        Button h1 = hatBtns[0];
        Button h2 = hatBtns[1];
        h1.onClick.AddListener(h1Switch);
        h2.onClick.AddListener(h2Switch);

    }

    void purchase(tileInfo ti, GameObject item)
    {
        if (ti.cost <= vr.coins)
        {
            vr.coins -= ti.cost;
            ti.purchased = true;
            if (item.TryGetComponent<Animation>(out Animation anim))
            {
                vr.hat = item.GetComponent<Animation>().clip;
                vr.purchasedAnimations.Add(item.GetComponent<Animation>().clip);
            }
            else
            {
                vr.tile = item.GetComponent<Image>().sprite;
                vr.purchasedTiles.Add(item.GetComponent<Image>().sprite);
            }
              item.transform.parent.GetChild(1).GetComponent<TMP_Text>().text = "";
            
        }
        updateCoins();
        vr.saveData();

    }

    void updateCoins()
    {
        TMP_Text txt = GameObject.FindGameObjectWithTag("coin").transform.GetChild(1).GetComponent<TMP_Text>();
        txt.text = vr.coins.ToString();
    }

    private void t1Switch()
    {
        currentTile = GameObject.FindGameObjectWithTag("t1").transform.gameObject;
        changeTile(currentTile);
    }
    private void t2Switch()
    {
        currentTile = GameObject.FindGameObjectWithTag("t2").transform.gameObject;
        changeTile(currentTile);
    }
    private void t3Switch()
    {
        currentTile = GameObject.FindGameObjectWithTag("t3").transform.gameObject;
        changeTile(currentTile);
    }

    private void h1Switch()
    {
        currentHat = GameObject.FindGameObjectWithTag("h1").transform.gameObject;
        changeHat(currentHat);
    }
    private void h2Switch()
    {
        currentHat = GameObject.FindGameObjectWithTag("h2").transform.gameObject;
        changeHat(currentHat);
    }

    private void changeTile(GameObject tile)
    {
       
        tileInfo ti = tile.GetComponent<tileInfo>();
        if (!ti.purchased)
        {
            purchase(ti, tile);
        }
        else
        {
            vr.tile = tile.GetComponent<Image>().sprite;
        }
    }
    private void changeHat(GameObject hat)
    {
        tileInfo ti = hat.GetComponent<tileInfo>();
        if (!ti.purchased)
        {
            purchase(ti, hat);
            //check
        }
        else
        {
            vr.hat = hat.GetComponent<Animation>().clip;
        }
    }
}
