using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coinController : MonoBehaviour
{

    GameObject player;
    bool towards = false;
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            towards = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            varController vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
            vr.addCoin();
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (towards)
        {
            Vector2 direction = player.transform.position - transform.position;
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }

}
