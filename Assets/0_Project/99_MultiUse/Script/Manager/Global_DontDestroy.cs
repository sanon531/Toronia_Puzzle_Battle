using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
