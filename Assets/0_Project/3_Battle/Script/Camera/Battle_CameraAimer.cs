using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using ToronPuzzle.Data;
namespace ToronPuzzle.Battle
{
    public class Battle_CameraAimer : MonoBehaviour
    {
        [SerializeField]
        KeyAimDictionary testkeytoAim;
        [SerializeField]
        CinemachineVirtualCamera _targetCamera;
        [SerializeField]
        Transform _cameraAim;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyValuePair <KeyCode,CameraAimName> keyValuePair in testkeytoAim)
                {

                    if (Input.GetKeyDown(keyValuePair.Key))
                    {
                        Vector3 _targetPos = CameraAimData.aimInfos[keyValuePair.Value].targetPos;
                        _targetPos += new Vector3(0, 0, -10);
                        _cameraAim.DOMove(_targetPos,0.5f); 

                        DOTween.To(
                            ()=> _targetCamera.m_Lens.OrthographicSize, 
                            x=> _targetCamera.m_Lens.OrthographicSize=x,
                            CameraAimData.aimInfos[keyValuePair.Value].CameraZoomSize,0.5f);
                        Debug.Log(CameraAimData.aimInfos[keyValuePair.Value].targetPos);
                    }

                }

            }
        }






    }

}
