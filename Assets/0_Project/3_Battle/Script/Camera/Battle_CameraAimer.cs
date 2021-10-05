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

        public static Battle_CameraAimer instance;
        [SerializeField]
        KeyAimDictionary testkeytoAim;
        [SerializeField]
        CinemachineVirtualCamera _targetCamera;
        [SerializeField]
        Transform _cameraAim;
        [SerializeField]
        Transform _WorldAim;

        [Header("For Test")]
        [SerializeField]
        bool Pressed;
        //계산 중에 하는 것
        public void BeginCameraAimer()
        {
            instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                Pressed = Pressed ? false : true;

            if (Pressed)
                SetAimCamera();
            else
                SetWorldCamera();
        }
        public void SetAimCamera ()
        {
            if (Input.anyKeyDown)
            {
                SetWorldByData(CameraAimEnum.Aim_Player);
                foreach (KeyValuePair<KeyCode, CameraAimEnum> keyValuePair in testkeytoAim)
                {
                    if (Input.GetKeyDown(keyValuePair.Key))
                        SetAimByData(keyValuePair.Value);
                }
            }
        }
        public static void SetAimByData(CameraAimEnum arg_cameraAim)
        {
            Vector3 _targetPos = CameraAimData.aimInfos[arg_cameraAim].targetPos;
            _targetPos += new Vector3(0, 0, -10);
            instance._cameraAim.DOMove(_targetPos, 0.5f);

            DOTween.To(
                () => instance._targetCamera.m_Lens.OrthographicSize,
                x => instance._targetCamera.m_Lens.OrthographicSize = x,
                CameraAimData.aimInfos[arg_cameraAim].CameraZoomSize, 0.5f);

        }
        public void SetWorldCamera()
        {
            if (Input.anyKeyDown)
            {
                SetAimByData(CameraAimEnum.Aim_Player);

                foreach (KeyValuePair<KeyCode, CameraAimEnum> keyValuePair in testkeytoAim)
                {
                    if (Input.GetKeyDown(keyValuePair.Key))
                    {
                        SetWorldByData(keyValuePair.Value);
                    }
                }

            }

        }
        public static void SetWorldByData(CameraAimEnum arg_cameraAim)
        {
            Vector3 _targetPos = CameraAimData.movInfos[arg_cameraAim].targetPos;
            instance._WorldAim.DOMove(_targetPos, 0.5f);
            Vector3 _targetScale = new Vector2(CameraAimData.movInfos[arg_cameraAim].ZoomSize, CameraAimData.movInfos[arg_cameraAim].ZoomSize);
            instance._WorldAim.DOScale(_targetScale, 0.5f);
        }


    }

}
