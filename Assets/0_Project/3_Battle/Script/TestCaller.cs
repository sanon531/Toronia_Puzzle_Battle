using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;
using ToronPuzzle;
public class TestCaller : MonoBehaviour
{
    [Header("For Test")]
    [SerializeField]
    bool _pressed,_paused = false;

    [SerializeField]
    KeyAimDictionary testkeytoAim;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _pressed = _pressed ? false : true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _paused = _paused ? false : true;
            if (_paused)
                Time.timeScale = 0;
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



}
