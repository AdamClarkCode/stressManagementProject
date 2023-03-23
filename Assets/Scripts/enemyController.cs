using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float hp;
    public float maxHp = 5;
    public healthBarController hbar;
    public float damage;
    public float speed;

    private SpriteRenderer spr;
    private Color cl;

    private GameObject player;
    private Rigidbody2D rb;

    float hurtTime;

    private float strength = 5;
    private bool moving = true;

    private varController vr;
    public GameObject coin;
    Vector2 move;

    public float thisDamage;

    void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        player = GameObject.FindGameObjectWithTag("Player");
        damage = 1 + (vr.damageStat/10);
        hp = maxHp;
        hbar.setHealth(hp, maxHp);

        rb = this.GetComponent<Rigidbody2D>();
        spr = this.GetComponent<SpriteRenderer>();
        cl = spr.color;
    }

    public void hurt()
    {
        hp -= damage;
        moving = false;
        rb.velocity = Vector2.zero;
        knockback();
        spr.color = Color.white;
        hurtTime = Time.time;

        hbar.setHealth(hp, maxHp);
        if (hp <= 0)
        {
            Instantiate(coin, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        if(direction.x > 0)
        {
            move.x = 1;
        }
        else
        {
            move.x = -1;
        }
        if (direction.y > 0)
        {
            move.y = 1;
        }
        else
        {
            move.y = -1;
        }

        if (moving)
        {
            rb.velocity = move * speed * Time.fixedDeltaTime;
        }
        if (Time.time > hurtTime + 0.2f)
        {
            spr.color = cl;
        }
    }

    public void knockback()
    {
        StopAllCoroutines();
        Vector2 direction = (transform.position - player.transform.position).normalized;
        rb.AddForce(direction * strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.15f);
        rb.velocity = Vector3.zero;
        moving = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController pC = collision.gameObject.GetComponent<playerController>();
            pC.hurt(thisDamage);
        }
    }
}
