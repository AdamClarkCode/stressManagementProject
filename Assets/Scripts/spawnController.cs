using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    private float spawnRate;
    private float spawnBigRate;

    public GameObject walking;
    public GameObject flying;
    private float curTime;

    private void Awake()
    {
        curTime = Time.fixedDeltaTime;
    }



    private void FixedUpdate()
    {
        float rnd1 = Random.Range(0.0f, 10000.0f);
        rnd1 += ((Time.fixedDeltaTime - curTime)/50);
        if(rnd1 >= 9800)
        {
            int rnd2 = Random.Range(0, 8);
            int rnd3 = Random.Range(0, 11);
            if(rnd3 < 10)
            {
                Instantiate(flying, spawnPoints[rnd2].transform.position, transform.rotation);
            }
            else
            {
                Instantiate(walking, spawnPoints[rnd2].transform.position, transform.rotation);
            }

        }

        //choose which to spawn
    }
}
