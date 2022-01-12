using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_DontDestroy : MonoBehaviour
{
    public static Global_DontDestroy _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
