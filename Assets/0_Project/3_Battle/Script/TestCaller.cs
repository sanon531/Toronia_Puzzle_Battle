using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;
using ToronPuzzle;
public class TestCaller : MonoBehaviour
{

    public static TestCaller instance;

    [Header("For Test")]

    [SerializeField]
    bool _pressed,_paused = false;

    [SerializeField]
    KeyAimDictionary testkeytoAim;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _pressed = _pressed ? false : true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _paused = _paused ? false : true;
            if (_paused)
                Time.timeScale = 1;
            else
                Time.timeScale = 1;

        }
        if (_pressed)
            SetAimCamera();
        else
            SetWorldCamera();



    }
    public void SetAimCamera()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyValuePair<KeyCode, CameraAimEnum> keyValuePair in testkeytoAim)
            {
                if (Input.GetKeyDown(keyValuePair.Key))
                {
                    Battle_CameraAimer.SetWorldByData(CameraAimEnum.Aim_Player);
                    Battle_CameraAimer.SetAimByData(keyValuePair.Value);

                }
            }
        }
    }
    public void SetWorldCamera()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyValuePair<KeyCode, CameraAimEnum> keyValuePair in testkeytoAim)
            {
                if (Input.GetKeyDown(keyValuePair.Key))
                {
                    Battle_CameraAimer.SetAimByData(CameraAimEnum.Aim_Player);
                    Battle_CameraAimer.SetWorldByData(keyValuePair.Value);
                }
            }

        }

    }

    public void DebugArrayShape(int[,] _ints)
    {
        int _maxX = _ints.GetLength(0);
        int _maxY = _ints.GetLength(1);
        string Lines = "";
        for (int i_y = _maxY - 1; i_y >= 0; i_y--)
        {
            for (int j_x = 0; j_x < _maxX; j_x++)
            {
                Lines += _ints[j_x, i_y].ToString();
            }
            Lines += "\n";
        }
        Debug.Log(Lines);

    }

    public void DebugArrayShape(string _beforeStr,int[,] _ints)
    {
        int _maxX = _ints.GetLength(0);
        int _maxY = _ints.GetLength(1);
        string Lines = _beforeStr;
        Lines += ": \n";
        for (int i_y = _maxY - 1; i_y >= 0; i_y--)
        {
            for (int j_x = 0; j_x < _maxX; j_x++)
            {
                Lines += _ints[j_x, i_y].ToString();
            }
            Lines += "\n";
        }
        Debug.Log(Lines);

    }


}
