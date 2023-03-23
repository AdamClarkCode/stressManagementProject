using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerMain : MonoBehaviour
{
    private varController vr;

    public Rigidbody2D rb;
    public float speed = 10f;

    Vector2 move;
    public SpriteRenderer spr;

    private void Start()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        speed = 50;

    }


}
