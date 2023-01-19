using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistantController : MonoBehaviour
{
    public static GameObject thisInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject.transform.parent.gameObject);

        if (thisInstance == null)
        {
            thisInstance = this.gameObject.transform.parent.gameObject;
        }
        else
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}

