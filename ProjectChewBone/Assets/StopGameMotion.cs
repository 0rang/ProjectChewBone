using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameMotion : MonoBehaviour
{
    public static StopGameMotion instance;
    [HideInInspector]
    public bool Motion = true;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void StopMotion()
    {
        Motion = false;
    }

    public void StartMotion()
    {
        Motion = true;
    }
}
