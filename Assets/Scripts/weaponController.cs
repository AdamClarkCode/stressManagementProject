using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject attack;
    private bool attackReady = true;
    private varController vr;

    private void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackReady)
        {
            attackReady = false;
            Vector3 midPoint = (collision.transform.position + this.transform.position) / 2;
            GameObject atk = Instantiate(attack, (collision.transform.position + midPoint) / 2, new Quaternion(0, 0, 0, 0));
            atk.transform.up = collision.transform.position - transform.position;
            collision.gameObject.SendMessage("hurt");
            StartCoroutine(cooldown());
        }
    }

    private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3f - (vr.attackSpeedStat/10));
        attackReady = true;
    }
}
