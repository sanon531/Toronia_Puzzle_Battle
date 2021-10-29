using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SimulateButtonThrouKey : MonoBehaviour
{
    [SerializeField]
    KeyCode key;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
            GetComponent<Button>().onClick.Invoke();
    }
}
