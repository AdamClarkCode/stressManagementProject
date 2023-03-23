using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    private varController vr;

    public Rigidbody2D rb;
    public float speed = 10f;

    Vector2 move;
    public SpriteRenderer spr;

    public Joystick jstick;

    public float hp;
    public float maxHp;
    public playerHealthBar hbar;
    public bool dead;
    private void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        maxHp = 100 + vr.healthStat;
        hp = maxHp;

        speed = 100 + (vr.speedStat * 2.5f);
        hbar.setMax(maxHp);
        hbar.setHealth(hp);
    }

    private void Update()
    {
        if (jstick.Horizontal >= 0.2f)
        {
            move.x = speed;
        }else if(jstick.Horizontal <= -0.2f)
        {
            move.x = -speed;
        }
        else
        {
            move.x = 0f;
        }

        if(move.x < 0)
        {
            spr.flipX = true;
        }
        else if(move.x > 0)
        {
            spr.flipX = false;
        }

        if (jstick.Vertical >= 0.2f)
        {
            move.y = speed;
        }
        else if (jstick.Vertical <= -0.2f)
        {
            move.y = -speed;
        }
        else
        {
            move.y = 0f;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = move * Time.fixedDeltaTime;
    }

    public void hurt(float enemyDamage)
    {
        hp -= enemyDamage;
        hbar.setHealth(hp);
        if (hp <= 0)
        {
            if (!dead)
            {
                dead = true;
                Debug.Log("dead");
                uiControllerScript ui = GameObject.FindGameObjectWithTag("uiController").GetComponent<uiControllerScript>();
                ui.death();
                Destroy(this);
            }
        }
    }
}

