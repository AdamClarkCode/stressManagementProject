using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curTIme = Time.time;
        if(curTIme >= time + 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
